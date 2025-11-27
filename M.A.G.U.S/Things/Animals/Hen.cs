using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class Hen : Thing
{
	public override Money Price => new(0, 0, 7);

    public override string Description => "A mature female chicken, specializing in the production of edible eggs. Easily kept and a staple of the peasant diet.";
}
