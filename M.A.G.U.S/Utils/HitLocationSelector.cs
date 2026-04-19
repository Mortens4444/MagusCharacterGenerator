using M.A.G.U.S.Enums;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Services;
using Mtf.Extensions;

namespace M.A.G.U.S.Utils;

public static class HitLocationSelector
{
    public static (PlaceOfAttack, string) GetLocation(AttackDirection attackDirection) =>
        GetLocationAsync(attackDirection, new AutoCombatRollService(), String.Empty).GetAwaiter().GetResult();

    public static async Task<(PlaceOfAttack, string)> GetLocationAsync(AttackDirection attackDirection, ICombatRollService rollService, string title)
    {
        var hitLocation = await GetAsync(rollService, title);
        var subLocation = String.Empty;

        switch (hitLocation)
        {
            case PlaceOfAttack.Head:
                var headPart = await GetOnHeadAsync(rollService, title);
                subLocation = headPart.GetDescription();
                break;

            case PlaceOfAttack.Torso:
                switch (attackDirection)
                {
                    case AttackDirection.Front:
                        var torsoPart = await GetOnTorsoAsync(rollService, title);
                        subLocation = torsoPart.GetDescription();
                        break;

                    case AttackDirection.Behind:
                        var torsoPartBack = await GetOnTorsoFromBehindAsync(rollService, title);
                        subLocation = torsoPartBack.GetDescription();
                        break;
                }
                break;

            case PlaceOfAttack.WeaponWieldingArm:
            case PlaceOfAttack.NonWeaponWieldingArm:
                var armPart = await GetOnArmAsync(rollService, title);
                subLocation = armPart.GetDescription();
                break;

            case PlaceOfAttack.RightLeg:
            case PlaceOfAttack.LeftLeg:
                var legPart = await GetOnLegAsync(rollService, title);
                subLocation = legPart.GetDescription();
                break;

            default:
                throw new NotImplementedException();
        }

        return (hitLocation, subLocation);
    }

    private static async Task<PlaceOfAttack> GetAsync(ICombatRollService rollService, string title)
    {
        var result = await rollService.RollAsync(ThrowType._1D9, title);
        return result switch
        {
            1 or 2 => PlaceOfAttack.WeaponWieldingArm,
            3 => PlaceOfAttack.NonWeaponWieldingArm,
            4 => PlaceOfAttack.RightLeg,
            5 => PlaceOfAttack.LeftLeg,
            6 or 7 or 8 => PlaceOfAttack.Torso,
            9 => PlaceOfAttack.Head,
            _ => throw new NotImplementedException(),
        };
    }

    private static async Task<PlaceOfAttackOnHead> GetOnHeadAsync(ICombatRollService rollService, string title)
    {
        var result = await rollService.RollAsync(ThrowType._1D10, title) - 1;
        return result switch
        {
            0 or 1 => PlaceOfAttackOnHead.Skull,
            2 or 3 => PlaceOfAttackOnHead.Forehead,
            4 => PlaceOfAttackOnHead.Temple,
            5 or 6 => PlaceOfAttackOnHead.Face,
            7 or 8 or 9 => PlaceOfAttackOnHead.NeckOrNape,
            _ => throw new NotImplementedException(),
        };
    }

    private static async Task<PlaceOfAttackOnArm> GetOnArmAsync(ICombatRollService rollService, string title)
    {
        var result = await rollService.RollAsync(ThrowType._1D10, title) - 1;
        return result switch
        {
            0 or 1 or 2 => PlaceOfAttackOnArm.Shoulder,
            3 or 4 => PlaceOfAttackOnArm.UpperArm,
            5 => PlaceOfAttackOnArm.Elbow,
            6 or 7 => PlaceOfAttackOnArm.Forearm,
            8 => PlaceOfAttackOnArm.Wrist,
            9 => PlaceOfAttackOnArm.BackOfHand,
            _ => throw new NotImplementedException(),
        };
    }

    private static async Task<PlaceOfAttackOnLeg> GetOnLegAsync(ICombatRollService rollService, string title)
    {
        var result = await rollService.RollAsync(ThrowType._1D10, title) - 1;
        return result switch
        {
            0 or 1 or 2 or 3 or 4 => PlaceOfAttackOnLeg.Thigh,
            5 => PlaceOfAttackOnLeg.Knee,
            6 or 7 => PlaceOfAttackOnLeg.Shin,
            8 => PlaceOfAttackOnLeg.Ankle,
            9 => PlaceOfAttackOnLeg.Foot,
            _ => throw new NotImplementedException(),
        };
    }

    private static async Task<PlaceOfAttackOnTorso> GetOnTorsoAsync(ICombatRollService rollService, string title)
    {
        var result = await rollService.RollAsync(ThrowType._1D10, title) - 1;
        return result switch
        {
            0 => PlaceOfAttackOnTorso.RightCollarbone,
            1 => PlaceOfAttackOnTorso.LeftCollarbone,
            2 => PlaceOfAttackOnTorso.Sternum,
            3 => PlaceOfAttackOnTorso.RightSideOfChest,
            4 => PlaceOfAttackOnTorso.LeftSideOfChest,
            5 or 6 => PlaceOfAttackOnTorso.SolarPlexus,
            7 => PlaceOfAttackOnTorso.RightSideOfAbdomen,
            8 => PlaceOfAttackOnTorso.LeftSideOfAbdomen,
            9 => PlaceOfAttackOnTorso.Groin,
            _ => throw new NotImplementedException(),
        };
    }

    private static async Task<PlaceOfAttackOnTorsoFromBehind> GetOnTorsoFromBehindAsync(ICombatRollService rollService, string title)
    {
        var result = await rollService.RollAsync(ThrowType._1D10, title) - 1;
        return result switch
        {
            0 => PlaceOfAttackOnTorsoFromBehind.RightShoulderBlade,
            1 or 2 => PlaceOfAttackOnTorsoFromBehind.LeftShoulderBlade,
            3 => PlaceOfAttackOnTorsoFromBehind.RightSideOfBack,
            4 => PlaceOfAttackOnTorsoFromBehind.LeftSideOfBack,
            5 => PlaceOfAttackOnTorsoFromBehind.RightSideOfWaist,
            6 => PlaceOfAttackOnTorsoFromBehind.LeftSideOfWaist,
            7 => PlaceOfAttackOnTorsoFromBehind.Buttocks,
            8 or 9 => PlaceOfAttackOnTorsoFromBehind.Spine,
            _ => throw new NotImplementedException(),
        };
    }
}
