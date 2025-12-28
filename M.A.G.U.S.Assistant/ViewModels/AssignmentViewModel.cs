using M.A.G.U.S.Bestiary;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Turn;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications.Specialities;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal class AssignmentViewModel : BaseViewModel
{
    private const int RoomDistance = 5;
    private const int DefaultEncounterDistance = 20;
    private readonly ISettings settings;
    private readonly Dictionary<Guid, int> enemyDistances = [];

    public AssignmentViewModel(ISettings settings, Character character)
    {
        this.settings = settings;
        Character = character;
    }

    public Character Character { get; init; }

    public bool IsIndoorEncounter { get; set; }

    public ObservableCollection<TurnViewModel> TurnHistory { get; } = [];

    public ObservableCollection<Creature> Enemies { get; } = [];

    public double EstimatedTime => 0;
    //Enemies.Count == 0
    //    ? 0
    //    : Enemies.Min(e => e.Distance / Character.Speed);

    public void AddTurn(TurnData turn)
    {
        var turnViewModel = new TurnViewModel(turn);
        if (settings.AssignmentTurnHistoryNewestOnTop)
        {
            TurnHistory.Insert(0, turnViewModel);
        }
        else
        {
            TurnHistory.Add(turnViewModel);
        }
    }

    public int GetDistance(Attacker enemy)
    {
        if (!enemyDistances.TryGetValue(enemy.Id, out int value))
        {
            value = CalculateInitialDistance(enemy);
            enemyDistances[enemy.Id] = value;
        }
        return value;
    }

    public void DecreaseDistance(Creature enemy, int amount)
    {
        int current = GetDistance(enemy);
        enemyDistances[enemy.Id] = Math.Max(0, current - amount);
    }

    public void RemoveEnemyDistance(Creature enemy) // Call it when am enemy is defeated or removed
    {
        if (enemyDistances.ContainsKey(enemy.Id))
        {
            enemyDistances.Remove(enemy.Id);
        }
    }

    private int CalculateInitialDistance(Attacker enemy)
    {
        if (IsIndoorEncounter)
        {
            return RoomDistance;
        }

        int baseDistance = DefaultEncounterDistance;

        var keenSight = Character.Race?.SpecialQualifications?.GetSpeciality<KeenSight>();
        if (keenSight != null)
        {
            baseDistance = (int)(baseDistance * keenSight.Multiplier);
        }

        //var stealth = enemy.Qualifications?.GetQualification<Stealth>();
        // if (stealth != null) 
        // {
        //     baseDistance /= 2;
        // }

        // VAGY: Méret alapú módosítás (pl. egy apró lényt nehezebb észrevenni messziről)
        // if (enemy.Size == Size.Tiny)
        // {
        //     baseDistance -= 10;
        // }
        return Math.Max(Attacker.MeleeDistance, baseDistance);
    }
}
