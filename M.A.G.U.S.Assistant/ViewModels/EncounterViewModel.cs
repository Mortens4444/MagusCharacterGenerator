using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.Views;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Enums;
using M.A.G.U.S.Extensions;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.CombatModifiers;
using M.A.G.U.S.GameSystem.Turn;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Utils;
using Mtf.Extensions;
using Mtf.Extensions.Services;
using Mtf.LanguageService.MAUI;
using Mtf.Maui.Controls.Messages;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class EncounterViewModel(ISettings settings, CharacterService characterService) : CharacterListLoaderViewModel(characterService)
{
    private Character? selectedCharacter;
    private Creature? selectedEnemy;
    private AssignmentViewModel? selectedAssignment;
    private readonly ISettings settings = settings;

    public ObservableCollection<Character> Characters { get; } = [];
    public ObservableCollection<Creature> Enemies { get; } = [];
    public ObservableCollection<Creature> AvailableEnemies { get; } = [];
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

    public Creature? SelectedEnemy
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

    public async Task LoadBestiaryAsync()
    {
        try
        {
            var creatures = "M.A.G.U.S.Bestiary".CreateInstancesFromNamespace<Creature>().OrderBy(c => Lng.Elem(c.Name));
            MainThread.BeginInvokeOnMainThread(() =>
            {
                AvailableEnemies.Clear();
                foreach (var creature in creatures)
                {
                    AvailableEnemies.Add(creature);
                }
            });
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    public async Task AddSingleCharacterToAssignments()
    {
        try
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (AvailableCharacters.Count == 1)
                {
                    SelectedCharacter = AvailableCharacters[0];
                    AddCharacter();
                }
            });
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    [RelayCommand(CanExecute = nameof(CanAddCharacter))]
    private void AddCharacter()
    {
        if (SelectedCharacter == null)
        {
            return;
        }

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
        // 1. Létrehozzuk a Setup VM-et
        var setupVm = new EnemySetupViewModel(SelectedEnemy);

        // 2. Megjelenítjük az oldalt (Feltételezve, hogy van egy NavigationService-ed vagy Shell)
        // Ez itt egy egyszerűsített navigációs hívás példa:
        var setupPage = new EnemySetupPage(setupVm);
        setupVm.OnEnemiesConfirmed += (configs) =>
        {
            ProcessConfirmedEnemies(configs);
            ShellNavigationService.ClosePage();
        };
        setupVm.OnCancel += () =>
        {
            ShellNavigationService.ClosePage();
        };
        await ShellNavigationService.ShowPage(setupPage).ConfigureAwait(true);
    }

    [RelayCommand(CanExecute = nameof(CanRunTurn))]
    private Task RunTurnAsync()
    {
        var assignmentsSnapshot = Assignments.ToList();
        var assignmentsToRemove = new HashSet<AssignmentViewModel>();
        var enemiesToRemove = new HashSet<Creature>();
        return Task.Run(() =>
        {
            foreach (var assignment in assignmentsSnapshot)
            {
                var turn = new TurnData
                {
                    Round = assignment.TurnHistory.Count + 1
                };

                var orderedInitiatives = GetInitiatives(assignment, turn);
                turn.Initiatives.AddRange(orderedInitiatives);
                foreach (var initiative in turn.Initiatives)
                {
                    var attackDirection = AttackDirection.Front;
                    //var attackDirection = (initiative.Attacker.Source as Creature)?.AttackDirection ?? AttackDirection.Front;
                    if (attackDirection == AttackDirection.Behind)
                    {
                        var ambushMod = new AttackFromAmbush();
                        // A combat logikának figyelembe kell vennie ezt a modifiert
                        // initiative.Attacker.AddTemporaryModifier(ambushMod); 
                    }

                    var (locationDescription, subLocation) = HitLocationSelector.GetLocation(attackDirection);
                    if (initiative.SelectedAttack != null && initiative.Attacker.Source.IsConscious)
                    {
                        initiative.AttackResolution = new AttackResolution(initiative)
                        {
                            Attack = initiative.SelectedAttack,
                            Direction = attackDirection,
                            HitLocation = locationDescription,
                            HitSubLocation = subLocation
                        };
                        if (initiative.AttackResolution.IsSuccessful)
                        {
                            var damage = Math.Max(0, initiative.AttackResolution.Attack.GetDamage());
                            if (initiative.Target.Source is Attacker targetEntity)
                            {
                                var wasConscious = targetEntity.IsConscious;
                                if (initiative.AttackResolution.IsHpDamage || !targetEntity.IsConscious)
                                {
                                    var impact = initiative.AttackResolution.Impact;
                                    switch (impact)
                                    {
                                        case AttackImpact.Fatal:
                                            targetEntity = initiative.Attacker.Source;
                                            break;
                                        case AttackImpact.Critical:
                                            targetEntity.Armor?.DecreaseArmorClass();
                                            break;
                                        default:
                                            damage -= Math.Max(0, targetEntity.Armor?.ArmorClass ?? 0);
                                            break;
                                    }

                                    targetEntity.ActualHealthPoints -= damage;
                                    targetEntity.ActualPainTolerancePoints -= 2 * damage;
                                    if (targetEntity.IsDead)
                                    {
                                        RemoveCharacter(targetEntity as Character);
                                        RemoveEnemy(targetEntity as Creature);
                                    }
                                }
                                else
                                {
                                    targetEntity.ActualPainTolerancePoints -= damage;
                                }

                                var targetName = GetName(targetEntity);
                                if (!targetEntity.IsConscious)
                                {
                                    var attacker = initiative.Attacker.Source as Character;
                                    var target = targetEntity as Creature;

                                    if (wasConscious)
                                    {
                                        MainThread.BeginInvokeOnMainThread(() =>
                                            WeakReferenceMessenger.Default.Send(
                                                new ShowInfoMessage(
                                                    Lng.Elem("Loss of consciousness"),
                                                    String.Format(System.Globalization.CultureInfo.InvariantCulture, Lng.Elem("'{0}' has lost consciousness."), Lng.Elem(targetName))
                                                )
                                            )
                                        );

                                        attacker?.BaseClass?.ExperiencePoints += target?.ExperiencePoints ?? 0;
                                    }

                                    if (targetEntity.IsDead)
                                    {
                                        if (targetEntity.IsUndead)
                                        {
                                            attacker?.BaseClass?.ExperiencePoints += target?.ExperiencePoints ?? 0;
                                        }
                                        MainThread.BeginInvokeOnMainThread(() =>
                                            WeakReferenceMessenger.Default.Send(new ShowInfoMessage(Lng.Elem("Die"), String.Format(System.Globalization.CultureInfo.InvariantCulture, Lng.Elem("'{0}' died."), Lng.Elem(targetName))))
                                        );
                                        var assignmentsForChar = RemoveCharacter(targetEntity as Character);
                                        foreach (var a in assignmentsForChar)
                                        {
                                            assignmentsToRemove.Add(a);
                                        }
                                        RemoveEnemy(target);
                                    }
                                }
                            }
                        }
                    }
                }
                if (orderedInitiatives.Any())
                {
                    assignment.AddTurn(turn);
                }

                CleanupDead();
            }
        });
    }

    private void ProcessConfirmedEnemies(List<EnemyConfigurationItem> configs)
    {
        foreach (var config in configs)
        {
            // 1. Lény példányosítása
            var newEnemy = config.CreateInstance();

            // 2. Speciális beállítások kezelése (amik nincsenek a Creature osztályban)
            // A te logikádban az AssignmentViewModel tárolja az enemy-t.
            // Mivel a Creature osztály lehet, hogy nem tartalmazza a 'Distance' vagy 'Direction' mezőt,
            // lehet, hogy egy Wrapper osztályba kell csomagolnod az Assignmenten belül,
            // VAGY az EncounterViewModel-ben kezeled ezeket egy Dictionary-ben.

            // Példa: Ambush modifier hozzáadása
            if (config.Direction == AttackDirection.Behind)
            {
                // Itt adod hozzá a modifiert. 
                // Feltételezve, hogy a Creature implementálja az ICombatModifierProvider-t vagy van Modifiers listája
                // newEnemy.ActiveModifiers.Add(new AttackFromAmbush());
            }

            // Támadási stratégia beállítása (ha a creature támogatja)
            newEnemy.AttackStrategy = config.Strategy;

            // Attack Mode
            if (config.SelectedAttackMode != null)
            {
                newEnemy.PreferredAttackMode = config.SelectedAttackMode;
            }

            // Hozzáadás a listához
            SelectedAssignment!.Enemies.Add(newEnemy);

            // Távolság beállítása az assignmentben (ha ott van tárolva)
            SelectedAssignment.SetDistance(newEnemy, config.Distance);
        }

        SelectedEnemy = null;
        RunTurnCommand.NotifyCanExecuteChanged();
    }

    private static string GetName(Attacker attacker)
    {
        return attacker switch
        {
            Character c => c.Name ?? String.Empty,
            Creature cr => cr.Name ?? String.Empty,
            _ => Lng.Elem("Unknown target")
        };
    }

    private static IOrderedEnumerable<InitiativeEntry> GetInitiatives(AssignmentViewModel assignment, TurnData turn)
    {
        var result = new List<InitiativeEntry>();
        if (assignment.Enemies.Any())
        {
            foreach (var enemy in assignment.Enemies.ToList())
            {
                int dist = assignment.GetDistance(enemy);
                var intendedAttack = enemy.GetRandomAttackMode();
                int range = Attacker.GetAttackRange(intendedAttack);
                if (dist > range)
                {
                    int speed = enemy.GetMaxMovementSpeed();
                    assignment.DecreaseDistance(enemy, speed);
                    AddInitiative(new CombatantRef(enemy), new CombatantRef(assignment.Character), null, result);
                    continue;
                }

                int attackCount = enemy.GetAttackCountForRound(turn.Round);
                for (var i = 0; i < attackCount; i++)
                {
                    AddInitiative(new CombatantRef(enemy), new CombatantRef(assignment.Character), intendedAttack, result);
                }
            }

            var target = (Attacker)(assignment.Character.AttackStrategy switch
            {
                AttackStrategy.AttackFirst => assignment.Enemies.First(),
                AttackStrategy.AttackRandom => assignment.Enemies[RandomProvider.GetSecureRandomInt(0, assignment.Enemies.Count)],
                AttackStrategy.AttackWeakest => assignment.Enemies.OrderBy(enemy => enemy.ActualHealthPoints).First(),
                AttackStrategy.AttackStrongest => assignment.Enemies.OrderBy(enemy => enemy.AttackValue).First(),
                _ => throw new NotImplementedException()
            });

            int characterAttackCount = assignment.Character.GetAttackCountForRound(turn.Round);
            var charIntendedAttack = assignment.Character.AttackModes.FirstOrDefault();
            int charDist = assignment.GetDistance(target);

            for (var i = 0; i < characterAttackCount; i++)
            {
                AddInitiative(new CombatantRef(assignment.Character), new CombatantRef(target), charIntendedAttack, result);
            }
        }
        return result.OrderByDescending(initiative => initiative.FinalInitiative);
    }

    private static void AddInitiative(CombatantRef attacker, CombatantRef target, Attack? attack, List<InitiativeEntry> result)
    {
        result.Add(new InitiativeEntry
        {
            Attacker = attacker,
            Target = target,
            SelectedAttack = attack,
            BaseInitiative = attacker.Source.InitiateValue,
            RolledValue = attacker.Source.RollInitiative()
        });
    }

    private bool CanAddEnemy() => SelectedEnemy != null && SelectedAssignment != null;

    private bool CanAddCharacter() => SelectedCharacter != null && !Characters.Contains(SelectedCharacter);

    private bool CanRunTurn() => Assignments.Count > 0;

    private List<AssignmentViewModel> RemoveCharacter(Character? character)
    {
        var result = new List<AssignmentViewModel>();
        if (character != null)
        {
            foreach (var assignment in Assignments)
            {
                if (assignment.Character == character)
                {
                    result.Add(assignment);
                }
            }
        }
        return result;
    }

    private bool RemoveEnemy(Attacker? enemy)
    {
        var result = false;
        if (enemy != null)
        {
            foreach (var assignment in Assignments)
            {
                result |= assignment.Enemies.Remove(enemy);
            }
        }
        return result;
    }

    private void CleanupDead()
    {
        var deadCharacters = Assignments.Where(a => a.Character.ActualHealthPoints <= 0).ToList();

        foreach (var dead in deadCharacters)
        {
            var enemiesToRedistribute = dead.Enemies.ToList();
            dead.Enemies.Clear();
            Assignments.Remove(dead);

            RedistributeEnemies(enemiesToRedistribute);
        }
    }

    private void RedistributeEnemies(IEnumerable<Attacker> enemies)
    {
        if (Assignments.Count == 0)
        {
            return;
        }

        var index = 0;
        foreach (var enemy in enemies)
        {
            Assignments[index % Assignments.Count].Enemies.Add(enemy);
            index++;
        }
    }
}
