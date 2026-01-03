using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class AbbitSteelHalfPlate : HalfPlate
{
	public override string Name => "Abbit-steel half plate";

	public override Money Price => new(300, 0, 0);

	public override int ArmorCheckPenalty => -4;

	public override int ArmorClass => 6;

	public override double Weight => 12;

    public override string Description => "Plate armour covering the torso, arms, and upper legs, crafted from the renowned Abbit-steel. A perfect blend of protection and mobility for the mounted warrior or skirmisher.";
}
