using M.A.G.U.S.Enums;

namespace M.A.G.U.S.GameSystem.Turn;

public sealed class AttackResolution
{
    public AttackResolution(InitiativeEntry initiative)
    {
        AttackRoll = initiative.Attacker.Source.RollAttack();
        var attack = initiative.Attacker.Source.AttackValue + AttackRoll;

        IsSuccessful = initiative.Target.Source.DefenseValue < attack; // Fix for ranged attacks (and for MartialArtist)
        IsHpDamage = attack > initiative.Target.Source.DefenseValue + 50;
    }

    public required Attack Attack { get; init; }

    public AttackDirection Direction { get; init; }

    public required string HitLocation { get; init; }

    public bool IsSuccessful { get; private init; }

    public bool IsHpDamage { get; private init; }

    public string? HitSubLocation { get; init; }

    public int AttackRoll { get; private init; }

    public AttackImpact Impact => AttackRoll == 100 ? AttackImpact.Critical : AttackRoll == 1 ? AttackImpact.Fatal : AttackImpact.Normal;

    public DateTime ExecutedAt { get; init; } = DateTime.UtcNow;
}
