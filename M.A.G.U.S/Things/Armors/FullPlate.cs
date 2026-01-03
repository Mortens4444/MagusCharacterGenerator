using M.A.G.U.S.Enums;

namespace M.A.G.U.S.Things.Armors;

public abstract class FullPlate : Armor
{
    public override PlaceOfAttack ProtectedMainPlaces => PlaceOfAttack.EveryWhere;

    public override PlaceOfAttackOnArm ProtectedArmParts => PlaceOfAttackOnArm.EveryWhere;

    public override PlaceOfAttackOnLeg ProtectedLegParts => PlaceOfAttackOnLeg.EveryWhere;

    public override PlaceOfAttackOnHead ProtectedHeadParts => PlaceOfAttackOnHead.EveryWhere;

    public override PlaceOfAttackOnTorso ProtectedTorsoFrontParts => PlaceOfAttackOnTorso.EveryWhere;

    public override PlaceOfAttackOnTorsoFromBehind ProtectedTorsoBackParts => PlaceOfAttackOnTorsoFromBehind.EveryWhere;
}
