using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class BronzeFullPlate : FullPlate
{
	public override string Name => "Bronze full plate";

	public override Money Price => new(160, 0, 0);

	public override int ArmorCheckPenalty => -8;

	public override int ArmorClass => 5;

	public override double Weight => 40;

    public override string Description => "A comprehensive set of articulated bronze plates covering the entire body. While visually magnificent, the soft metal is prone to dents and requires a strong wearer to bear its weight.";
}
