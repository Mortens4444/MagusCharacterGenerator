using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.GameSystem;
using Mtf.Extensions;
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
                ((Command)AddCharacterCommand).ChangeCanExecute();
            }
        }
    }

    public Creature? SelectedEnemy
    {
        get => selectedEnemy;
        set => SetProperty(ref selectedEnemy, value);
    }

    public AssignmentViewModel? SelectedAssignment
    {
        get => selectedAssignment;
        set => SetProperty(ref selectedAssignment, value);
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
        var assignment = Assignments.First(a => a.Character == SelectedAssignment!.Character);
        assignment.Enemies.Add(SelectedEnemy!);
        SelectedEnemy = null;
    }

    [RelayCommand(CanExecute = nameof(CanRunTurn))]
    private void RunTurn()
    {
        foreach (var assignment in Assignments.ToList())
        {
            foreach (var enemy in assignment.Enemies.ToList())
            {
                ResolveAttack(assignment.Character, enemy);
            }
        }

        CleanupDead();
    }

    private bool CanAddEnemy() => SelectedEnemy != null && SelectedAssignment != null;

    private bool CanAddCharacter() => SelectedCharacter != null && !Characters.Contains(SelectedCharacter);

    private bool CanRunTurn() => Assignments.Count > 0;

    private void ResolveAttack(Character character, Creature enemy)
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
