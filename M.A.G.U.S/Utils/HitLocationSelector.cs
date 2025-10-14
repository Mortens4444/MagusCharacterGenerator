using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;

namespace M.A.G.U.S.Utils;

public static class HitLocationSelector
{
    private static readonly DiceThrow diceThrow = new();

    public static PlaceOfAttack Get()
    {
        var result = diceThrow._1K9();
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
}
