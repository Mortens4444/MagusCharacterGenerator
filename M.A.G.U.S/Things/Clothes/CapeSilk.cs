using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class CapeSilk : Thing
{
	public override string Name => "Cloak, silk";

	public override Money Price => new(2, 0, 0);

    public override string Description => "A light, costly cloak made from imported silk. It serves less for warmth and more as a mark of nobility and status, often finely embroidered.";
}
