using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Turn;
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

    public EncounterViewModel(CharacterService characterService) : base(characterService)
    {
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
        Assignments.Add(new AssignmentViewModel(SelectedCharacter!));
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
                var roll = initiative.Attacker.Source.RollAttack();
                var attackMode = initiative.Attacker.Source.GetRandomAttackMode();
                initiative.AttackResolution = new AttackResolution
                {
                    Attack = attackMode,
                    AttackRoll = roll,
                    Direction = attackDirection,
                    HitLocation = locationDescription,
                    HitSubLocation = subLocation,
                    IsSuccessful = initiative.Target.Source.DefenseValue < initiative.Attacker.Source.AttackValue + roll
                };
            }

            assignment.AddTurn(turn);
        }

        CleanupDead();
    }

    private static IOrderedEnumerable<InitiativeEntry> GetInitiatives(AssignmentViewModel assignment, TurnData turn)
    {
        var initiatives = new List<InitiativeEntry>();
        foreach (var enemy in assignment.Enemies.ToList())
        {
            for (var i = 0; i < enemy.AttacksPerRound; i++) // need to handle 0.5 or 0.33 attacks per round!
            {
                initiatives.Add(new InitiativeEntry
                {
                    Attacker = new CombatantRef
                    {
                        Name = enemy.Name,
                        Source = enemy
                    },
                    Target = new CombatantRef
                    {
                        Name = assignment.Character.Name,
                        Source = assignment.Character
                    },
                    BaseInitiative = enemy.InitiatingValue,
                    RolledValue = enemy.RollInitiative()
                });
            }
        }
        var weapon = assignment.Character.PrimaryWeapon ?? assignment.Character.SecondaryWeapon;
        var attacksPerRound = weapon?.AttacksPerRound ?? assignment.Character.AttacksPerRound; // need to handle 0.5 or 0.33 attacks per round!

        var target = (Attacker)(assignment.Character.AttackStrategy switch
        {
            AttackStrategy.AttackFirst => assignment.Enemies.First(),
            AttackStrategy.AttackRandom => assignment.Enemies[RandomProvider.GetSecureRandomInt(0, assignment.Enemies.Count)],
            AttackStrategy.AttackWeakest => assignment.Enemies.OrderBy(enemy => enemy.HealthPoints).First(),
            AttackStrategy.AttackStrongest => assignment.Enemies.OrderBy(enemy => enemy.AttackValue).First(),
            _ => throw new NotImplementedException()
        });

        initiatives.Add(new InitiativeEntry
        {
            Attacker = new CombatantRef
            {
                Name = assignment.Character.Name,
                Source = assignment.Character
            },
            Target = new CombatantRef
            {
                Name = target.Name,
                Source = target
            },
            BaseInitiative = assignment.Character.InitiatingValue,
            RolledValue = assignment.Character.RollInitiative()
        });

        return initiatives.OrderByDescending(initiative => initiative.FinalInitiative);
    }

    private bool CanAddEnemy() => SelectedEnemy != null && SelectedAssignment != null;

    private bool CanAddCharacter() => SelectedCharacter != null && !Characters.Contains(SelectedCharacter);

    private bool CanRunTurn() => Assignments.Count > 0;

    private void ResolveAttack(Character character, Creature enemy, TurnData turn)
    {
        //enemy.HealthPoints -= character.PrimaryWeapon?.GetDamage() ?? character.GetDamage();
        if (enemy.HealthPoints <= 0)
        {
            RemoveEnemy(enemy);
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
        var deadCharacters = Assignments.Where(a => a.Character.HealthPoints <= 0).ToList();

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
