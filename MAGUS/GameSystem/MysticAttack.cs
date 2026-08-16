using MAGUS.Enums;
using Newtonsoft.Json;

namespace MAGUS.GameSystem;

public abstract class MysticAttack : Attack
{
    public const int CastingRangeInMeters = 30;

    /// <summary>A round has 10 segments; casting time is spent out of this budget.</summary>
    public const int SegmentsPerRound = 10;

    /// <summary>Power rolled against the target's magic resistance. Null means the attack bypasses the resistance roll entirely (always connects); 0 is a valid, rollable power that can still be raised via mana/psi empowerment.</summary>
    public int? Power { get; init; }

    public MagicResistanceType ResistanceType { get; init; }

    public int CastingTimeInSegments { get; init; }

    public int DurationInRounds { get; init; }

    /// <summary>How many times this specific attack can be cast in a single round, based on its own casting time.</summary>
    public int MaxCastsPerRound => Math.Max(1, SegmentsPerRound / Math.Max(1, CastingTimeInSegments));

    [JsonConstructor]
    protected MysticAttack() : base() { }

    protected MysticAttack(string name, int? power, MagicResistanceType resistanceType, int castingTimeInSegments, int durationInRounds, Func<int> getDamageCallback)
        : base(name, power ?? 0, getDamageCallback)
    {
        Power = power;
        ResistanceType = resistanceType;
        CastingTimeInSegments = castingTimeInSegments;
        DurationInRounds = durationInRounds;
    }
}
