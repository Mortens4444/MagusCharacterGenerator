using M.A.G.U.S.Enums;

namespace M.A.G.U.S.Things.Armors;

public abstract class ScaleArmor : Armor
{
    public override PlaceOfAttack ProtectedMainPlaces =>
            PlaceOfAttack.Torso |
            PlaceOfAttack.WeaponWieldingArm |
            PlaceOfAttack.NonWeaponWieldingArm |
            PlaceOfAttack.RightLeg |
            PlaceOfAttack.LeftLeg;

    public override PlaceOfAttackOnArm ProtectedArmParts =>
        PlaceOfAttackOnArm.Shoulder |
        PlaceOfAttackOnArm.UpperArm |
        PlaceOfAttackOnArm.Elbow;

    public override PlaceOfAttackOnLeg ProtectedLegParts =>
        PlaceOfAttackOnLeg.Thigh |
        PlaceOfAttackOnLeg.Knee;

    public override PlaceOfAttackOnTorso ProtectedTorsoFrontParts => PlaceOfAttackOnTorso.Everywhere;

    public override PlaceOfAttackOnTorsoFromBehind ProtectedTorsoBackParts => PlaceOfAttackOnTorsoFromBehind.Everywhere;
}
