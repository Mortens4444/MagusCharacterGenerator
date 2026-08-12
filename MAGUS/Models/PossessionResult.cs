using MAGUS.Enums;

namespace MAGUS.Models;

public sealed class PossessionResult
{
    public PossessionOutcome Outcome { get; init; }

    public TimeSpan Duration { get; init; }
}