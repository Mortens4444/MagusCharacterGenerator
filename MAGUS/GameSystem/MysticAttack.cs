using MAGUS.Enums;
using Newtonsoft.Json;

namespace MAGUS.GameSystem;

public abstract class MysticAttack : Attack
{
    public const int CastingRangeInMeters = 30;

    /// <summary>A round has 10 segments; casting time is spent out of this budget.</summary>
    public const int SegmentsPerRound = 10;

    public int InitiateValue { get; init; }

    public MagicResistanceType ResistanceType { get; init; }

    public int CastingTimeInSegments { get; init; }

    public int DurationInRounds { get; init; }

    /// <summary>How many times this specific attack can be cast in a single round, based on its own casting time.</summary>
    public int MaxCastsPerRound => Math.Max(1, SegmentsPerRound / Math.Max(1, CastingTimeInSegments));

    [JsonConstructor]
    protected MysticAttack() : base() { }

    protected MysticAttack(string name, int initiateValue, MagicResistanceType resistanceType, int castingTimeInSegments, int durationInRounds, Func<int> getDamageCallback)
        : base(name, initiateValue, getDamageCallback)
    {
        InitiateValue = initiateValue;
        ResistanceType = resistanceType;
        CastingTimeInSegments = castingTimeInSegments;
        DurationInRounds = durationInRounds;
    }
}
