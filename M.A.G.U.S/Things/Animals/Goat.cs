using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class Goat : Thing
{
	public override Money Price => new(0, 3, 0);

    public override string Description => "A nimble, hardy beast that thrives in rocky or poor lands where others starve. Provides milk, meat, and leather, and can be surprisingly stubborn when led.";
}
