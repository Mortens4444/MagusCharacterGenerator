using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Turn;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Utils;
using Mtf.Extensions;
using Mtf.Extensions.Services;
using Mtf.LanguageService.MAUI;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class EncounterViewModel : CharacterListLoaderViewModel
{
    private Character? selectedCharacter;
    private Creature? selectedEnemy;
    private AssignmentViewModel? selectedAssignment;
    private readonly ISettings settings;

    public EncounterViewModel(ISettings settings, CharacterService characterService) : base(characterService)
    {
        this.settings = settings;
    }

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

    public Task LoadBestiaryAsync()
    {
        return Task.Run(() =>
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
        });
    }

    [RelayCommand(CanExecute = nameof(CanAddCharacter))]
    private void AddCharacter()
    {
        Characters.Add(SelectedCharacter!);
        Assignments.Add(new AssignmentViewModel(settings, SelectedCharacter!));
        if (SelectedAssignment == null)
        {
            SelectedAssignment = Assignments.LastOrDefault();
        }
        AvailableCharacters.Remove(SelectedCharacter!);
        SelectedCharacter = null;
    }

    [RelayCommand(CanExecute = nameof(CanAddEnemy))]
    private void AddEnemy()
    {
        SelectedAssignment!.Enemies.Add(SelectedEnemy!);
        SelectedEnemy = null;
        RunTurnCommand.NotifyCanExecuteChanged();
    }

    [RelayCommand(CanExecute = nameof(CanRunTurn))]
    private void RunTurn()
    {
        foreach (var assignment in Assignments.ToList())
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
                var (locationDescription, subLocation) = HitLocationSelector.GetLocation(attackDirection);
                if (initiative.SelectedAttack != null)
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
                        var damage = initiative.AttackResolution.Attack.GetDamage();
                        if (initiative.Target.Source is Creature creature)
                        {
                            if (initiative.AttackResolution.IsHpDamage || creature.PainTolerancePoints.Value <= 0) // Need to fix for dragons, dragon has min and max only (I wnat a page, where you can set the actual values)
                            {
                                creature.HealthPoints -= damage;
                                if (creature.HealthPoints <= 0)
                                {
                                    RemoveEnemy(creature);
                                }
                            }
                            else
                            {
                                creature.PainTolerancePoints -= damage;
                            }
                        }
                        else if (initiative.Target.Source is Character character)
                        {
                            if (initiative.AttackResolution.IsHpDamage || character.ActualPainTolerancePoints <= 0)
                            {
                                character.ActualHealthPoints -= damage;
                                if (character.ActualHealthPoints <= 0)
                                {
                                    RemoveCharacter(character);
                                }
                            }
                            else
                            {
                                character.ActualPainTolerancePoints -= damage;
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
            int charDist = assignment.GetDistance(target);

            var charIntendedAttack = assignment.Character.AttackModes.FirstOrDefault();
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

    private void RemoveCharacter(Character character)
    {
        foreach (var assignment in Assignments)
        {
            // assignment.Enemies attack another character
            //assignment.Remove();
        }
    }

    private void RemoveEnemy(Creature enemy)
    {
        foreach (var assignment in Assignments)
        {
            assignment.Enemies.Remove(enemy);
        }
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

    private void RedistributeEnemies(IEnumerable<Creature> enemies)
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
