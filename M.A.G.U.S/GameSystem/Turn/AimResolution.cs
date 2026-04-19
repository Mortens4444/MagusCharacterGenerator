using M.A.G.U.S.Enums;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Utils;
using Mtf.Extensions;

namespace M.A.G.U.S.GameSystem.Turn;

public sealed class AimResolution : ResolutionBase
{
    public const int BaseAimDefense = 30;

    private AimResolution() { }

    public static async Task<AimResolution> CreateAsync(
        InitiativeEntry initiative,
        int targetDistanceMeters,
        MovementType movement,
        WeatherCondition weather,
        ICombatRollService rollService,
        string title,
        Attack attack,
        AttackDirection attackDirection,
        string hitLocationTitle,
        bool manualRollService)
    {
        var rollValue = await rollService.RollAsync(ThrowType._1D100, title);
        var aimTotal = initiative.Attacker.Source.AimValue + rollValue;

        var sizeModifier = DefenseHelper.Get(initiative.Target.Source.Size);
        var movementDefense = DefenseHelper.Get(movement);
        var weatherDefense = DefenseHelper.Get(weather);

        var defenseValue = sizeModifier + targetDistanceMeters + weatherDefense;

        defenseValue += initiative.Target.Source is Character character &&
                        character.SpecialQualifications.GetSpeciality<SlanDodgeAgainstRangedAttacks>() != null
            ? initiative.Target.Source.DefenseValue
            : BaseAimDefense + movementDefense;

        var successful = aimTotal > defenseValue;
        var (hitLocation, subLocation) = successful || !manualRollService ? await HitLocationSelector.GetLocationAsync(attackDirection, rollService, hitLocationTitle).ConfigureAwait(false) : (PlaceOfAttack.None, String.Empty);
        return new AimResolution
        {
            Attack = attack,
            RollValue = rollValue,
            IsSuccessful = successful,
            IsHpDamage = aimTotal > defenseValue + OverHitValue,
            Direction = attackDirection,
            HitLocation = hitLocation.GetDescription(),
            HitSubLocation = subLocation
        };
    }
}
