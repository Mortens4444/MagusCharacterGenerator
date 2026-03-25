using M.A.G.U.S.GameSystem.Attributes;

namespace M.A.G.U.S.Enums;

/// <summary>
/// Represents the possible outcomes of an Ansinatis possession attempt.
/// </summary>
public enum PossessionOutcome
{
    /// <summary>
    /// The target goes insane and dies within 1D6 hours.
    /// </summary>
    [DiceThrow(ThrowType._1D6)]
    Death,

    /// <summary>
    /// The target becomes confused and loses control for 1D6 days, after which their original personality returns.
    /// </summary>
    [DiceThrow(ThrowType._1D6)]
    TemporaryConfusion,

    /// <summary>
    /// The target becomes confused, and within 1D6 days the Ansinatis personality permanently takes over.
    /// </summary>
    [DiceThrow(ThrowType._1D6)]
    PermanentTakeover,

    /// <summary>
    /// Perfect fusion: two souls share the body, alternating control every 1D6 weeks.
    /// </summary>
    [DiceThrow(ThrowType._1D6)]
    DualSoul
}