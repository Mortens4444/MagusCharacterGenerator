using M.A.G.U.S.Enums;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Armors;
using Mtf.Extensions.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace M.A.G.U.S.GameSystem;

public abstract class Attacker
{
    public const int MeleeDistance = 2;
    private readonly DiceThrow diceThrow = new();

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int actualHealthPoints;
    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int? actualPainTolerancePoints;
    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private string name = String.Empty;
    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private Armor? armor;

    public Guid Id { get; init; } = Guid.NewGuid();

    public event PropertyChangedEventHandler? PropertyChanged;
    public event EventHandler? Died;
    public event EventHandler? LostConsciousness;

    public virtual Armor? Armor
    {
        get => armor;
        set
        {
            if (armor != value)
            {
                armor = value;
                OnPropertyChanged();
            }
        }
    }

    public virtual string Name
    {
        get => name;
        set
        {
            if (name != value)
            {
                name = value;
                OnPropertyChanged();
            }
        }
    }

    public virtual Size Size { get; protected set; }

    public virtual int InitiateValue { get; set; }

    public virtual int AttackValue { get; set; }

    public virtual int DefenseValue { get; set; }

    public virtual int AimValue { get; set; }

    public int ActualHealthPoints
    {
        get => actualHealthPoints;
        set
        {
            if (actualHealthPoints != value)
            {
                var wasAlive = actualHealthPoints > 0;
                if (value < actualHealthPoints)
                {
                    var damage = actualHealthPoints - value;
                    if (actualPainTolerancePoints.HasValue)
                    {
                        ActualPainTolerancePoints = actualPainTolerancePoints - (2 * damage);
                    }
                }

                actualHealthPoints = value;
                OnPropertyChanged();

                if (wasAlive && actualHealthPoints <= 0)
                {
                    Died?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }

    public int? ActualPainTolerancePoints
    {
        get => actualPainTolerancePoints;
        set
        {
            if (actualPainTolerancePoints != value)
            {
                var wasConscious = (actualPainTolerancePoints ?? 1) > 0;
                actualPainTolerancePoints = value;
                OnPropertyChanged();

                if (wasConscious && (actualPainTolerancePoints ?? 1) <= 0)
                {
                    LostConsciousness?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }

    public virtual double AttacksPerRound { get; protected set; } = 1;

    public AttackStrategy AttackStrategy { get; set; } = AttackStrategy.AttackFirst;

    public List<ICombatModifier> TemporaryModifiers { get; } = [];

    public abstract List<Attack> AttackModes { get; protected set; }

    public abstract List<Speed> Speeds { get; }

    public int RollInitiative() => diceThrow._1D10();

    public int RollAttack() => diceThrow._1D100();

    public abstract int GetDamage();

    public Attack GetRandomAttackMode()
    {
        if (AttackModes == null || AttackModes.Count == 0)
        {
            throw new InvalidOperationException("No attack modes available.");
        }

        int randomIndex = RandomProvider.GetSecureRandomInt(0, AttackModes.Count);
        return AttackModes[randomIndex];
    }

    public static int GetAttackRangeInMeters(Attack attack)
    {
        if (attack is RangedAttack rangeAttack)
        {
            return rangeAttack.Weapon.Distance;
        }
        return MeleeDistance;
    }

    /// <summary>
    /// Calculates how many attacks occur in the specific round based on APR.
    /// Handles fractional attacks (0.5 = 1 attack every 2 rounds).
    /// </summary>
    public int GetAttackCountForRound(int currentRound)
    {
        // Case 1: Multiple attacks per round (e.g., 1, 2, 3)
        if (AttacksPerRound >= 1.0)
        {
            return (int)AttacksPerRound;
        }

        // Case 2: Fractional attacks (e.g., 0.5, 0.33)
        // 0.5 means 1 attack every 2 rounds (Round 1: Yes, Round 2: No, Round 3: Yes)
        // 0.33 means 1 attack every 3 rounds.

        // Calculate period (e.g., 0.5 -> 2)
        // Using Round to prevent floating point errors (1/0.3333 = 3)
        int period = (int)Math.Round(1.0 / AttacksPerRound);

        if (period <= 0)
        {
            return 0;
        }

        // Check if this is an "active" round
        // (Round 1 - 1) % 2 == 0 -> Attack
        // (Round 2 - 1) % 2 == 1 -> Skip
        if ((currentRound - 1) % period == 0)
        {
            return 1;
        }

        return 0;
    }

    public int GetMaxMovementSpeed()
    {
        return Speeds.FirstOrDefault(s => s.SpeedLevel == SpeedLevel.Fastest)?.Value
            ?? Speeds
                .OrderByDescending(s => s.SpeedLevel)
                .Select(s => s.Value ?? 0)
                .FirstOrDefault();
    }

    public bool IsDead => ActualHealthPoints <= 0;

    public AttackDirection AttackDirection { get; set; }

    public virtual bool IsUndead { get; set; } = false;

    public bool IsConscious => ActualPainTolerancePoints == null || ActualPainTolerancePoints > 0 && (!IsDead || IsUndead);

    public void AddTemporaryModifier(ICombatModifier combatModifier)
    {
        TemporaryModifiers.Add(combatModifier);
    }

    public void RemoveTemporaryModifiers()
    {
        TemporaryModifiers.Clear();
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
