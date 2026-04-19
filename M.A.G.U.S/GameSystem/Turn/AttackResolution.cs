using M.A.G.U.S.Enums;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Utils;
using Mtf.Extensions;

namespace M.A.G.U.S.GameSystem.Turn;

public sealed class AttackResolution : ResolutionBase
{
    private AttackResolution() { }

    public static async Task<AttackResolution> CreateAsync(
        InitiativeEntry initiative,
        ICombatRollService rollService,
        string title,
        Attack attack,
        AttackDirection attackDirection,
        string hitLocationTitle,
        bool manualRollService)
    {
        var rollValue = await rollService.RollAsync(ThrowType._1D100, title);
        var attackTotal = initiative.Attacker.Source.AttackValue + rollValue;

        var successful = attackTotal > initiative.Target.Source.DefenseValue;
        var (hitLocation, subLocation) = successful || !manualRollService ? await HitLocationSelector.GetLocationAsync(attackDirection, rollService, hitLocationTitle).ConfigureAwait(false) : (PlaceOfAttack.None, String.Empty);

        return new AttackResolution
        {
            Attack = attack,
            RollValue = rollValue,
            IsSuccessful = successful,
            IsHpDamage = attackTotal > initiative.Target.Source.DefenseValue + OverHitValue,
            Direction = attackDirection,
            HitLocation = hitLocation.GetDescription(),
            HitSubLocation = subLocation

        };
    }
}
