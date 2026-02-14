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
using System.Globalization;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class EncounterViewModel : CharacterListLoaderViewModel, IDisposable
{
    private Character? selectedCharacter;
    private Attacker? selectedEnemy;
    private AssignmentViewModel? selectedAssignment;
    private readonly ISettings settings;
    private readonly CombatEngine combatEngine;

    public EncounterViewModel(ISettings settings, CharacterService characterService, CombatEngine combatEngine) : base(characterService)
    {
        this.combatEngine = combatEngine;
        this.settings = settings;
    }

    public ObservableCollection<Character> Characters { get; } = [];
    public ObservableCollection<Attacker> Enemies { get; } = [];
    public ObservableCollection<Attacker> AvailableEnemies { get; } = [];
    public ObservableCollection<AssignmentViewModel> Assignments { get; } = [];

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
                }
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
            }
        });
    }

    [RelayCommand(CanExecute = nameof(CanAddCharacter))]
    private void AddCharacter()
    {
        if (SelectedCharacter == null)
        {
            return;
        }

        SelectedCharacter.LostConsciousness += LostConsciousnessHandler;
        SelectedCharacter.Died += DieHandler;

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
    private void RunTurn()
    {
        if (IsEncounterOver())
        {
            NewEncounter();
        }
        if (EncounterState == EncounterState.NotStarted)
        {
            EncounterState = EncounterState.InProgress;
        }
        var assignmentsSnapshot = Assignments.ToList();
        foreach (var assignment in assignmentsSnapshot)
        {
            var round = assignment.TurnHistory.Count + 1;
            CombatEngine.ProcessAssignmentTurn(assignment, round);
        }
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
            AddXpForUndeads(assignment.Character, diedEntity);
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
        if (!activeAssignments.Any())
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

        EncounterState = EncounterState.Finished;
        RunTurnCommand.NotifyCanExecuteChanged();
        // tovább: UI értesítés, scoreboard, stb.
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
        if (sender is Attacker target)
        {
            var assignment = Assignments.FirstOrDefault(a => a.Enemies.Contains(target));
            if (assignment != null)
            {
                AddXp(assignment.Character, target);
            }
        }

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

    private void AddXpForUndeads(Attacker attacker, Attacker target)
    {
        if (target.IsDead && target.IsUndead)
        {
            AddXp(attacker, target);
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
