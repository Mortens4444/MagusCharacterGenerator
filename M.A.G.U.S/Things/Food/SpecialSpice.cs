using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class SpecialSpice : Thing
{
	public override string Name => "Special spice";

	public override Money Price => new(0, 0, 20);

    public override string Description => "A very rare and potent spice, such as saffron or nutmeg, used only by the very richest families or master chefs to craft dishes of unparalleled flavour.";
}
