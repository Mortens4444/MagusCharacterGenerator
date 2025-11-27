using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Trappings;

public class YokeHorseHarness : Thing
{
	public override string Name => "Yoke";

	public override Money Price => new(0, 0, 80);

    public override string Description => "A heavy wooden cross-piece that fits over the neck of a draught horse, alongside the necessary straps and traces used to attach the animal to a plough or large cart.";
}
