using MAGUS.Enums;

namespace MAGUS.Things.Armors;

public abstract class Breastplate : Armor
{
    public override PlaceOfAttack ProtectedMainPlaces => PlaceOfAttack.Torso;

    public override PlaceOfAttackOnTorso ProtectedTorsoFrontParts => PlaceOfAttackOnTorso.Everywhere;

    public override PlaceOfAttackOnTorsoFromBehind ProtectedTorsoBackParts => PlaceOfAttackOnTorsoFromBehind.Everywhere;
}
