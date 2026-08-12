using MAGUS.Enums;
using MAGUS.Interfaces;
using MAGUS.Utils;
using Mtf.Extensions;

namespace MAGUS.GameSystem.Turn;

public sealed class ForcedResolution : ResolutionBase
{
    private ForcedResolution(int damage)
    {
        this.damage = damage;
    }

    public static async Task<ForcedResolution> CreateAsync(InitiativeEntry initiative, int damage, AttackDirection attackDirection, ICombatRollService rollService, string hitLocationTitle)
    {
        var (hitLocation, subLocation) = await HitLocationSelector.GetLocationAsync(attackDirection, rollService, hitLocationTitle).ConfigureAwait(false);

        return new ForcedResolution(damage)
        {
            Attack = initiative.SelectedAttack!,
            IsSuccessful = true,
            IsHpDamage = true,
            Direction = attackDirection,
            HitLocation = hitLocation.GetDescription(),
            HitSubLocation = subLocation
        };
    }
}