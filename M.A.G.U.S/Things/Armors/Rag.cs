using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class Rag : Armor
{
	public override Money Price => new(0, 1, 0);

	public override int ArmorCheckPenalty => 0;

	public override int ArmorClass => 1;

	public override double Weight => 5;

    public override string Name => "Cloth";

    public override string Description => "A piece of tattered, simple cloth wrapped about the body. Offers only the most pathetic defense against the elements and virtually none against a drawn weapon.";
}
