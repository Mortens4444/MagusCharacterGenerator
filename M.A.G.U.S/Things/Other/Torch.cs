using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Torch : Thing
{
	public override Money Price => new(0, 0, 1);

    public override string Description => "A wooden staff with a pitch-soaked cloth head that is lit with fire. Provides a strong, smoking light, best used for navigating outdoor darkness.";
}
