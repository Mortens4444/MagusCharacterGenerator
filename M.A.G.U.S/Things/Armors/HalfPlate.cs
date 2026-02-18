using M.A.G.U.S.Enums;

namespace M.A.G.U.S.Things.Armors;

public abstract class HalfPlate : Armor
{
    public override PlaceOfAttack ProtectedMainPlaces =>
        PlaceOfAttack.Torso | PlaceOfAttack.Head | PlaceOfAttack.WeaponWieldingArm |
        PlaceOfAttack.NonWeaponWieldingArm | PlaceOfAttack.LeftLeg | PlaceOfAttack.RightLeg;

    public override PlaceOfAttackOnArm ProtectedArmParts => PlaceOfAttackOnArm.Everywhere;

    public override PlaceOfAttackOnHead ProtectedHeadParts => PlaceOfAttackOnHead.Skull | PlaceOfAttackOnHead.Forehead | PlaceOfAttackOnHead.Temple | PlaceOfAttackOnHead.NeckOrNape;

    public override PlaceOfAttackOnLeg ProtectedLegParts => PlaceOfAttackOnLeg.Thigh;
}
