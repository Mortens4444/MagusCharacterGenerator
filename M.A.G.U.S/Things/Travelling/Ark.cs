using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class Ark : Thing
{
	public override string Name => "Ark";

	public override Money Price => new(50, 0, 0);

    public override string Description => "A massive, lumbering vessel of mythical proportions, spoken of in ancient texts. If one exists, it is built to survive the wrath of a great flood, carrying many souls and beasts upon the turbulent waters.";
}
