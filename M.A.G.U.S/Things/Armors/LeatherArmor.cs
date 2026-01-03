using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class LeatherArmor : Armor
{
	public override string Name => "Studded leather";

	public override Money Price => new(0, 4, 0);

	public override int ArmorCheckPenalty => 0;

	public override int ArmorClass => 1;

	public override double Weight => 8;

    public override string Description => "Simple armour made from boiled or treated leather hides. Provides basic protection against minor cuts and scrapes, favoured by bandits, hunters, and those who need unrestricted movement.";

    public override PlaceOfAttack ProtectedMainPlaces =>
        PlaceOfAttack.Torso | PlaceOfAttack.WeaponWieldingArm |
        PlaceOfAttack.NonWeaponWieldingArm | PlaceOfAttack.LeftLeg | PlaceOfAttack.RightLeg;

    public override PlaceOfAttackOnArm ProtectedArmParts => PlaceOfAttackOnArm.Shoulder | PlaceOfAttackOnArm.UpperArm;

    public override PlaceOfAttackOnLeg ProtectedLegParts => PlaceOfAttackOnLeg.Thigh;
}
