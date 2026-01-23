using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Armors;

public class NaturalArmor : Armor, INotForSale
{
    private readonly int armorClass;
    private readonly int armorCheckPenalty;

    public NaturalArmor() : this(1, 0) { }
    
    public NaturalArmor(int armorClass, int armorCheckPenalty = 0)
    {
        this.armorClass = armorClass;
        this.armorCheckPenalty = armorCheckPenalty;
    }

    public override string Name => "Natural protection";

	public override Money Price => Money.Free;

	public override int ArmorCheckPenalty => armorCheckPenalty;

    public override int ArmorClass => armorClass;

    public override double Weight => 0;

    public override string Description => "Natural protection for the creature.";

    public override PlaceOfAttack ProtectedMainPlaces =>
        PlaceOfAttack.Torso | PlaceOfAttack.Head |
        PlaceOfAttack.WeaponWieldingArm | PlaceOfAttack.NonWeaponWieldingArm |
        PlaceOfAttack.LeftLeg | PlaceOfAttack.RightLeg;

    public override PlaceOfAttackOnArm ProtectedArmParts => PlaceOfAttackOnArm.EveryWhere;

    public override PlaceOfAttackOnLeg ProtectedLegParts => PlaceOfAttackOnLeg.EveryWhere;

    public override PlaceOfAttackOnHead ProtectedHeadParts => (PlaceOfAttackOnHead)0x1F;

    public override PlaceOfAttackOnTorso ProtectedTorsoFrontParts => PlaceOfAttackOnTorso.EveryWhere;

    public override PlaceOfAttackOnTorsoFromBehind ProtectedTorsoBackParts => PlaceOfAttackOnTorsoFromBehind.EveryWhere;
}
