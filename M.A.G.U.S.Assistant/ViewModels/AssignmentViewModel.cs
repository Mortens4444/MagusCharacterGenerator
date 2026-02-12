using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Turn;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Utils;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal class AssignmentViewModel : BaseViewModel
{
    private const int RoomDistance = 5;
    private readonly ISettings settings;
    private readonly Dictionary<Guid, int> enemyDistances = [];

    public bool IsFinished { get; set; }

    public bool IsCharacterConscious => Character.IsConscious;

    public bool HasActiveOpponents => Enemies.Any(o => o.ActualHealthPoints > 0);

    public AssignmentViewModel(ISettings settings, Character character)
    {
        this.settings = settings;
        Character = character;
    }

    public Character Character { get; init; }

    public bool IsIndoorEncounter { get; set; }

    public ObservableCollection<TurnViewModel> TurnHistory { get; } = [];

    public ObservableCollection<Attacker> Enemies { get; } = [];

    public double EstimatedTime => 0;
    //Enemies.Count == 0
    //    ? 0
    //    : Enemies.Min(e => e.Distance / Character.Speed);

    public void AddTurn(TurnData turn)
    {
        if (Character.IsDead)
        {
            return;
        }

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

    public int GetDistanceInMeters(Attacker enemy)
    {
        if (!enemyDistances.TryGetValue(enemy.Id, out int value))
        {
            value = CalculateInitialDistance(enemy);
            enemyDistances[enemy.Id] = value;
        }
        return value;
    }

    public void SetDistance(Attacker enemy, int distance)
    {
        if (!enemyDistances.TryAdd(enemy.Id, distance))
        {
            enemyDistances[enemy.Id] = distance;
        }
    }

    public void DecreaseDistance(Attacker enemy, int amount)
    {
        int current = GetDistanceInMeters(enemy);
        enemyDistances[enemy.Id] = Math.Max(0, current - amount);
    }

    public void RemoveEnemyDistance(Attacker enemy) // Call it when an enemy is defeated or removed
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

        int baseDistance = GameSystem.Constants.DefaultEncounterDistance;

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

        baseDistance += DistanceModifierHelper.Get(enemy.Size);
        return Math.Max(Attacker.MeleeDistance, baseDistance);
    }

    public bool CanContinueCombat()
    {
        return IsCharacterConscious && Enemies.Any(enemy => enemy.IsConscious);
    }
}
