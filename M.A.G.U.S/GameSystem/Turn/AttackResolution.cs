using M.A.G.U.S.Enums;

namespace M.A.G.U.S.GameSystem.Turn;

public sealed class AttackResolution
{
    public required Attack Attack { get; init; }

    public AttackDirection Direction { get; init; }

    public required string HitLocation { get; init; }

    public required bool IsSuccessful { get; init; }

    public string? HitSubLocation { get; init; }

    public int AttackRoll { get; init; }

    public AttackImpact Impact => AttackRoll == 100 ? AttackImpact.Critical : AttackRoll == 1 ? AttackImpact.Fatal : AttackImpact.Normal;

    public DateTime ExecutedAt { get; init; } = DateTime.UtcNow;
}
