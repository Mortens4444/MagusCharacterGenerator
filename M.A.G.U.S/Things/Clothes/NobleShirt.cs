using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class NobleShirt : Thing
{
	public override string Name => "Noble shirt";

	public override Money Price => new(0, 2, 0);

    public override string Description => "An undergarment of fine linen or bleached cotton, often decorated with lace or embroidery at the collar. Worn by the rich to avoid chafing from rougher outer garments.";
}
