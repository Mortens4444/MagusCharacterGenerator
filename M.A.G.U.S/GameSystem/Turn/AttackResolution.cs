using M.A.G.U.S.Enums;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.GameSystem.Turn;

public sealed class AttackResolution : ResolutionBase
{
    private AttackResolution() { }

    public static async Task<AttackResolution> CreateAsync(
        InitiativeEntry initiative,
        ICombatRollService rollService,
        string title,
        Attack attack,
        AttackDirection direction,
        string hitLocation,
        string? hitSubLocation)
    {
        var rollValue = await rollService.RollAsync(ThrowType._1D100, title);
        var attackTotal = initiative.Attacker.Source.AttackValue + rollValue;

        return new AttackResolution
        {
            Attack = attack,
            RollValue = rollValue,
            IsSuccessful = attackTotal > initiative.Target.Source.DefenseValue,
            IsHpDamage = attackTotal > initiative.Target.Source.DefenseValue + OverHitValue,
            Direction = direction,
            HitLocation = hitLocation,
            HitSubLocation = hitSubLocation
        };
    }
}
