using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class RingArmor : Armor
{
	public override string Name => "Ring mail";

	public override Money Price => new(2, 0, 0);

	public override int ArmorCheckPenalty => -1;

	public override int ArmorClass => 1;

	public override double Weight => 12;

    public override string Description => "A garment, often leather or thick cloth, onto which large metal rings are individually stitched or linked. Provides minimal protection compared to true mail, but is cheap and quick to repair.";

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
