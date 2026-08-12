using MAGUS.Enums;

namespace MAGUS.Things.Armors;

public abstract class FullPlate : Armor
{
    public override PlaceOfAttack ProtectedMainPlaces => PlaceOfAttack.Everywhere;

    public override PlaceOfAttackOnArm ProtectedArmParts => PlaceOfAttackOnArm.Everywhere;

    public override PlaceOfAttackOnLeg ProtectedLegParts => PlaceOfAttackOnLeg.Everywhere;

    public override PlaceOfAttackOnHead ProtectedHeadParts => PlaceOfAttackOnHead.Everywhere;

    public override PlaceOfAttackOnTorso ProtectedTorsoFrontParts => PlaceOfAttackOnTorso.Everywhere;

    public override PlaceOfAttackOnTorsoFromBehind ProtectedTorsoBackParts => PlaceOfAttackOnTorsoFromBehind.Everywhere;
}
