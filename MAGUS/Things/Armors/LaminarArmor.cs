using MAGUS.Enums;

namespace MAGUS.Things.Armors;

public abstract class LaminarArmor : Armor
{
    public override PlaceOfAttack ProtectedMainPlaces =>
            PlaceOfAttack.Torso |
            PlaceOfAttack.WeaponWieldingArm |
            PlaceOfAttack.NonWeaponWieldingArm |
            PlaceOfAttack.RightLeg |
            PlaceOfAttack.LeftLeg;

    public override PlaceOfAttackOnArm ProtectedArmParts =>
        PlaceOfAttackOnArm.Shoulder |
        PlaceOfAttackOnArm.UpperArm;

    public override PlaceOfAttackOnLeg ProtectedLegParts =>
        PlaceOfAttackOnLeg.Thigh;

    public override PlaceOfAttackOnTorso ProtectedTorsoFrontParts => PlaceOfAttackOnTorso.Everywhere;

    public override PlaceOfAttackOnTorsoFromBehind ProtectedTorsoBackParts => PlaceOfAttackOnTorsoFromBehind.Everywhere;
}
