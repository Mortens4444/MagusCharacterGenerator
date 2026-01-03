using M.A.G.U.S.Enums;

namespace M.A.G.U.S.Things.Armors;

public abstract class Armor : Thing
{
    public virtual int ArmorCheckPenalty => 0;

    public virtual int ArmorClass { get; set; } = 0;

    public virtual PlaceOfAttack ProtectedMainPlaces => PlaceOfAttack.Torso;

    public virtual PlaceOfAttackOnArm ProtectedArmParts => PlaceOfAttackOnArm.None;

    public virtual PlaceOfAttackOnLeg ProtectedLegParts => PlaceOfAttackOnLeg.None;

    public virtual PlaceOfAttackOnHead ProtectedHeadParts => PlaceOfAttackOnHead.None;

    public virtual PlaceOfAttackOnTorso ProtectedTorsoFrontParts => PlaceOfAttackOnTorso.EveryWhere;

    public virtual PlaceOfAttackOnTorsoFromBehind ProtectedTorsoBackParts => PlaceOfAttackOnTorsoFromBehind.EveryWhere;

    public void DecreaseArmorClass()
    {
        if (ArmorClass > 0)
        {
            ArmorClass--;
        }
    }
}
