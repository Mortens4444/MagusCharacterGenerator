using MAGUS.Enums;

namespace MAGUS.Things.Armors;

public abstract class Chainmail : Armor
{
    public override PlaceOfAttack ProtectedMainPlaces =>
        PlaceOfAttack.Torso | PlaceOfAttack.WeaponWieldingArm |
        PlaceOfAttack.NonWeaponWieldingArm | PlaceOfAttack.LeftLeg | PlaceOfAttack.RightLeg;

    public override PlaceOfAttackOnArm ProtectedArmParts => PlaceOfAttackOnArm.Shoulder | PlaceOfAttackOnArm.UpperArm;

    public override PlaceOfAttackOnLeg ProtectedLegParts => PlaceOfAttackOnLeg.Thigh;
}
