using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Enums;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.Views;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Extensions;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Interfaces;
using Mtf.LanguageService.MAUI;
using Mtf.Maui.Controls.Messages;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class EncounterViewModel : CharacterListLoaderViewModel, IDisposable
{
    private Character? selectedCharacter;
    private Attacker? selectedEnemy;
    private AssignmentViewModel? selectedAssignment;
    private readonly ISettings settings;
    private bool showControls = true;
    private bool isRunningTurns;
    private AssignmentViewModel? previousSelectedAssignment;

    public ObservableCollection<TurnViewModel> SelectedTurnHistory { get; } = [];

    public EncounterViewModel(ISettings settings, CharacterService characterService) : base(characterService)
    {
        this.settings = settings;
    }

    public ObservableCollection<Character> Characters { get; } = [];
    public ObservableCollection<Attacker> Enemies { get; } = [];
    public ObservableCollection<Attacker> AvailableEnemies { get; } = [];
    public ObservableCollection<AssignmentViewModel> Assignments { get; } = [];
    
    public ISettings Settings
    {
        get => settings;
    }

    public bool ShowControls
    {
        get => showControls;
        set => SetProperty(ref showControls, value);
    }

    public bool IsRunningTurns
    {
        get => isRunningTurns;
        set
        {
            if (SetProperty(ref isRunningTurns, value))
            {
                RunTurnCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public Character? SelectedCharacter
    {
        get => selectedCharacter;
        set
        {
            if (SetProperty(ref selectedCharacter, value))
            {
                AddCharacterCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public Attacker? SelectedEnemy
    {
        get => selectedEnemy;
        set
        {
            if (SetProperty(ref selectedEnemy, value))
            {
                AddEnemyCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public AssignmentViewModel? SelectedAssignment
    {
        get => selectedAssignment;
        set
        {
            if (SetProperty(ref selectedAssignment, value))
            {
                if (previousSelectedAssignment != null)
                {
                    if (previousSelectedAssignment.TurnHistory is INotifyCollectionChanged oldColl)
                    {
                        oldColl.CollectionChanged -= TurnHistory_CollectionChanged;
                    }
                }

                previousSelectedAssignment = selectedAssignment;
                RebuildSelectedTurnHistory();

                if (selectedAssignment?.TurnHistory is INotifyCollectionChanged coll)
                {
                    coll.CollectionChanged += TurnHistory_CollectionChanged;
                }

                AddEnemyCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public EncounterState EncounterState { get; private set; }

    public async Task LoadBestiaryAsync()
    {
        try
        {
            var creatures = PreloadService.Instance.Creatures;
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                AvailableEnemies.Clear();
                foreach (var creature in creatures)
                {
                    AvailableEnemies.Add(creature);
                }
            }).ConfigureAwait(true);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    public void AddSingleCharacterToAssignments()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            try
            {
                if (AvailableCharacters.Count == 1)
                {
                    SelectedCharacter = AvailableCharacters[0];
                    AddCharacter();
                    PickRandomEnemy();
                }
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
            }
        });
    }

    [RelayCommand]
    private void ToggleShowControls()
    {
        ShowControls = !ShowControls;
    }

    [RelayCommand(CanExecute = nameof(CanAddCharacter))]
    private void AddCharacter()
    {
        if (SelectedCharacter == null)
        {
            return;
        }

        if (Characters.Any(c => c.Id == SelectedCharacter.Id))
        {
            SelectedCharacter = null;
            return;
        }

        SelectedCharacter.LostConsciousness += LostConsciousnessHandler;
        SelectedCharacter.Died += DieHandler;
        SelectedCharacter.SetMaxValues();

        Characters.Add(SelectedCharacter);
        Assignments.Add(new AssignmentViewModel(settings, SelectedCharacter));
        SelectedAssignment ??= Assignments.LastOrDefault();
        AvailableCharacters.Remove(SelectedCharacter);
        SelectedCharacter = null;
    }

    [RelayCommand]
    private void PickRandomEnemy()
    {
        SelectedEnemy = EnemyProvider.PickWeightedRandom(AvailableEnemies, e => e.Occurrence.GetWeight());
    }

    [RelayCommand(CanExecute = nameof(CanAddEnemy))]
    private async Task AddEnemyAsync()
    {
        if (SelectedAssignment == null || SelectedEnemy == null)
        {
            return;
        }

        if (SelectedEnemy is Creature creature)
        {
            var setupVm = new EnemySetupViewModel(creature);
            var setupPage = new EnemySetupPage(setupVm);
            setupVm.OnEnemiesConfirmed += (configs) =>
            {
                ProcessConfirmedEnemies(configs, setupVm.MaxSimultaneousAttacks);
                ShellNavigationService.ClosePageAsync();
            };
            setupVm.OnCancel += () =>
            {
                ShellNavigationService.ClosePageAsync();
            };
            await ShellNavigationService.ShowPageAsync(setupPage).ConfigureAwait(true);
        }
        else
        {
            SelectedEnemy.LostConsciousness += LostConsciousnessHandler;
            SelectedEnemy.Died += DieHandler;

            SelectedAssignment!.Enemies.Add(SelectedEnemy);
            SelectedAssignment.SetDistance(SelectedEnemy, GameSystem.Constants.DefaultEncounterDistance);

            SelectedEnemy = null;
            RunTurnCommand.NotifyCanExecuteChanged();
        }
    }

    [RelayCommand(CanExecute = nameof(CanRunTurn))]
    private async Task RunTurnAsync()
    {
        var hasEnemies = Assignments.Any(a => a.Enemies?.Count > 0);
        if (!hasEnemies && SelectedEnemy is Creature autoCreature)
        {
            var setupVm = new EnemySetupViewModel(autoCreature);
            var configs = setupVm.ConfigItems.ToList();
            ProcessConfirmedEnemies(configs, setupVm.MaxSimultaneousAttacks);
            SelectedEnemy = null;
            RunTurnCommand.NotifyCanExecuteChanged();
            return;
        }

        if (IsEncounterOver())
        {
            await NewEncounter().ConfigureAwait(false);
            AddSingleCharacterToAssignments();
            return;
        }

        IsRunningTurns = true;
        ShowControls = false;
        RunTurnCommand.NotifyCanExecuteChanged();

        var assignmentsSnapshot = Assignments.ToList();
        await Task.Run(() =>
        {
            foreach (var assignment in assignmentsSnapshot)
            {
                var round = assignment.TurnHistory.Count + 1;
                CombatEngine.ProcessAssignmentTurn(assignment, round);
            }
        }).ConfigureAwait(false);

        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            IsRunningTurns = false;
            RunTurnCommand.NotifyCanExecuteChanged();

            if (IsEncounterOver())
            {
                EndEncounter();
            }
        }).ConfigureAwait(false);
    }

    private void RebuildSelectedTurnHistory()
    {
        SelectedTurnHistory.Clear();
        if (SelectedAssignment == null)
        {
            return;
        }

        var src = SelectedAssignment.TurnHistory;
        IEnumerable<TurnViewModel> items = settings.AssignmentTurnHistoryNewestOnTop ? src.Reverse() : src;
        foreach (var t in items)
        {
            SelectedTurnHistory.Add(t);
        }
    }

    private void TurnHistory_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (e.Action == NotifyCollectionChangedAction.Add && e.NewItems != null)
            {
                foreach (TurnViewModel newTurn in e.NewItems)
                {
                    if (settings.AssignmentTurnHistoryNewestOnTop)
                    {
                        SelectedTurnHistory.Insert(0, newTurn);
                    }
                    else
                    {
                        SelectedTurnHistory.Add(newTurn);
                    }
                }
            }
            else
            {
                RebuildSelectedTurnHistory();
            }
        });
    }

    private Task NewEncounter()
    {
        Dispose();
        Assignments.Clear();
        Characters.Clear();
        return LoadCharactersAsync();
    }

    private void DieHandler(object? sender, EventArgs e)
    {
        if (sender is not Attacker diedEntity)
        {
            return;
        }

        diedEntity.Died -= DieHandler;
        diedEntity.LostConsciousness -= LostConsciousnessHandler;

        var assignment = Assignments.FirstOrDefault(a => a.Enemies.Contains(diedEntity));
        if (assignment != null)
        {
            AddXp(assignment.Character, diedEntity);
        }

        MainThread.BeginInvokeOnMainThread(() =>
        {
            try
            {
                var charAssignment = Assignments.FirstOrDefault(a => a.Character == diedEntity);
                if (charAssignment != null)
                {
                    var enemiesToRedistribute = charAssignment.Enemies.ToList();
                    charAssignment.Enemies.Clear();
                    charAssignment.IsFinished = true;
                    //Assignments.Remove(charAssignment);
                    RedistributeEnemies(enemiesToRedistribute);
                }
                else
                {
                    var enemyAssignment = Assignments.FirstOrDefault(a => a.Enemies.Contains(diedEntity));
                    if (enemyAssignment != null)
                    {
                        enemyAssignment.RemoveEnemyDistance(diedEntity);
                        enemyAssignment.Enemies.Remove(diedEntity);
                    }
                }

                RunTurnCommand.NotifyCanExecuteChanged();
                ShowDiedMessage(diedEntity);

                if (IsEncounterOver())
                {
                    EndEncounter();
                }
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
            }
        });
    }
    private bool IsEncounterOver()
    {
        var activeAssignments = Assignments.Where(a => !a.IsFinished).ToList();
        if (activeAssignments.Count == 0)
        {
            return true;
        }

        var anyAliveCharacter = activeAssignments.Any(a => !a.Character.IsDead);
        if (!anyAliveCharacter)
        {
            return true;
        }

        var anyAliveEnemy = activeAssignments.SelectMany(a => a.Enemies).Any(e => !e.IsDead);
        if (!anyAliveEnemy)
        {
            return true;
        }

        return false;
    }

    private void EndEncounter()
    {
        foreach (var assignment in Assignments)
        {
            assignment.Character.LostConsciousness -= LostConsciousnessHandler;
            assignment.Character.Died -= DieHandler;
            RemoveEnemyHandlers(assignment.Enemies);
        }
        ShowControls = true;
        EncounterState = EncounterState.Finished;
        RunTurnCommand.NotifyCanExecuteChanged();
    }

    private static void ShowDiedMessage(Attacker diedEntity)
    {
        WeakReferenceMessenger.Default.Send(
            new ShowInfoMessage(
                Lng.Elem("Die"),
                String.Format(CultureInfo.InvariantCulture, Lng.Elem("'{0}' died."), Lng.Elem(diedEntity.Name))
            )
        );
    }

    private void LostConsciousnessHandler(object? sender, EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
            WeakReferenceMessenger.Default.Send(
                new ShowInfoMessage(
                    Lng.Elem("Loss of consciousness"),
                    String.Format(CultureInfo.InvariantCulture, Lng.Elem("'{0}' has lost consciousness."), Lng.Elem(((Attacker)sender!).Name))
                )
            )
        );
    }

    private void ProcessConfirmedEnemies(List<EnemyConfigurationItem> configs, int maxSimultaneousAttacks)
    {
        foreach (var config in configs)
        {
            var newEnemy = config.CreateInstance();
            newEnemy.AttackDirection = config.Direction;
            newEnemy.AttackStrategy = config.Strategy;
            newEnemy.LostConsciousness += LostConsciousnessHandler;
            newEnemy.Died += DieHandler;

            if (config.SelectedAttackMode != null)
            {
                newEnemy.PreferredAttackMode = config.SelectedAttackMode;
            }

            SelectedAssignment!.Enemies.Add(newEnemy);
            SelectedAssignment.SetDistance(newEnemy, config.Distance);
            SelectedAssignment.MaxSimultaneousAttacks = maxSimultaneousAttacks;
        }

        SelectedEnemy = null;
        RunTurnCommand.NotifyCanExecuteChanged();
    }

    private bool CanAddEnemy() => SelectedEnemy != null && SelectedAssignment != null;

    private bool CanAddCharacter() => SelectedCharacter != null && !Characters.Any(c => c.Id == SelectedCharacter.Id);

    private bool CanRunTurn() => Assignments.Count > 0;

    private void RemoveEnemyHandlers(IEnumerable<Attacker> attackers)
    {
        foreach (var enemy in attackers)
        {
            enemy.LostConsciousness -= LostConsciousnessHandler;
            enemy.Died -= DieHandler;
        }
    }

    private void RedistributeEnemies(IEnumerable<Attacker> enemies)
    {
        var enemiesList = enemies.ToList();
        if (Assignments.Count == 0)
        {
            RemoveEnemyHandlers(enemiesList);
            return;
        }

        var index = 0;
        foreach (var enemy in enemiesList)
        {
            Assignments[index % Assignments.Count].Enemies.Add(enemy);
            index++;
        }
    }

    private void AddXp(Attacker attacker, Attacker target)
    {
        if (attacker is Character character)
        {
            if (target is Creature creature)
            {
                character.BaseClass!.ExperiencePoints += creature.ExperiencePoints;
            }
            else if (target is Character targetCharacter)
            {
                character.BaseClass!.ExperiencePoints += targetCharacter.BaseClass.ExperiencePoints;
            }
            _ = characterService.SaveAsync(character);
        }
    }

    public void Dispose()
    {
        foreach (var character in Characters)
        {
            character.LostConsciousness -= LostConsciousnessHandler;
            character.Died -= DieHandler;
        }

        foreach (var assignment in Assignments)
        {
            RemoveEnemyHandlers(assignment.Enemies);
        }
    }
}
