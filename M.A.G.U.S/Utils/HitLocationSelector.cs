using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using Mtf.Extensions;

namespace M.A.G.U.S.Utils;

public static class HitLocationSelector
{
    private static readonly DiceThrow diceThrow = new();

    public static (PlaceOfAttack, string) GetLocation(AttackDirection attackDirection)
    {
        var hitLocation = Get();
        var subLocation = String.Empty;

        switch (hitLocation)
        {
            case PlaceOfAttack.Head:
                var headPart = GetOnHead();
                subLocation = headPart.GetDescription();
                break;

            case PlaceOfAttack.Torso:

                switch (attackDirection)
                {
                    case AttackDirection.Front:
                        var torsoPart = GetOnTorso();
                        subLocation = torsoPart.GetDescription();
                        break;
                    case AttackDirection.Behind:
                        var torsoPartBack = GetOnTorsoFromBehind();
                        subLocation = torsoPartBack.GetDescription();
                        break;
                    default:
                        break;
                }
                break;

            case PlaceOfAttack.WeaponWieldingArm:
            case PlaceOfAttack.NonWeaponWieldingArm:
                var armPart = GetOnArm();
                subLocation = armPart.GetDescription();
                break;

            case PlaceOfAttack.RightLeg:
            case PlaceOfAttack.LeftLeg:
                var legPart = GetOnLeg();
                subLocation = legPart.GetDescription();
                break;

            default:
                throw new NotImplementedException();
        }

        return (hitLocation, subLocation);
    }

    private static PlaceOfAttack Get()
    {
        var result = diceThrow._1D9();
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

    private static PlaceOfAttackOnHead GetOnHead()
    {
        var result = diceThrow._1D10() - 1;
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

    private static PlaceOfAttackOnArm GetOnArm()
    {
        var result = diceThrow._1D10() - 1;
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

    private static PlaceOfAttackOnLeg GetOnLeg()
    {
        var result = diceThrow._1D10() - 1;
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

    private static PlaceOfAttackOnTorso GetOnTorso()
    {
        var result = diceThrow._1D10() - 1;
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

    private static PlaceOfAttackOnTorsoFromBehind GetOnTorsoFromBehind()
    {
        var result = diceThrow._1D10() - 1;
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
