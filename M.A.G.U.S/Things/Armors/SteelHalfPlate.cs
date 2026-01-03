using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class SteelHalfPlate : HalfPlate
{
	public override string Name => "Steel half plate";

	public override Money Price => new(120, 0, 0);

	public override int ArmorCheckPenalty => -6;

	public override int ArmorClass => 5;

	public override double Weight => 30;

    public override string Description => "Steel plate that protects the torso and upper limbs, leaving the lower body in mail or leather. A favoured choice for cavalry, balancing solid protection with the necessity of riding.";
}
