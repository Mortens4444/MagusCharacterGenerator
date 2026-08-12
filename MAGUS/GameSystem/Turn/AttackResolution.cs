using MAGUS.Classes.Fighter;
using MAGUS.Enums;
using MAGUS.Interfaces;
using MAGUS.Utils;
using Mtf.Extensions;

namespace MAGUS.GameSystem.Turn;

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
            IsHpDamage = attackTotal - initiative.Target.Source.DefenseValue >= (initiative.Attacker.Source is Character c && c.BaseClass is Nerton ? NertonOverHitValue : OverHitValue),
            Direction = attackDirection,
            HitLocation = hitLocation.GetDescription(),
            HitSubLocation = subLocation

        };
    }
}
