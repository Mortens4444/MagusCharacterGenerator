using M.A.G.U.S.Enums;

namespace M.A.G.U.S.Things.Armors;

public abstract class Breastplate : Armor
{
    public override PlaceOfAttack ProtectedMainPlaces => PlaceOfAttack.Torso;

    public override PlaceOfAttackOnTorso ProtectedTorsoFrontParts => PlaceOfAttackOnTorso.Everywhere;

    public override PlaceOfAttackOnTorsoFromBehind ProtectedTorsoBackParts => PlaceOfAttackOnTorsoFromBehind.Everywhere;
}
