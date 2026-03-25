using M.A.G.U.S.Enums;

namespace M.A.G.U.S.Models;

public sealed class PossessionResult
{
    public PossessionOutcome Outcome { get; init; }

    public TimeSpan Duration { get; init; }
}