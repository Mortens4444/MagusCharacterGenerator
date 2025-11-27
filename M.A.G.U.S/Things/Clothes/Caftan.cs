using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class Caftan : Thing
{
	public override string Name => "Caftan";

	public override Money Price => new(0, 5, 0);

    public override string Description => "A long, flowing outer garment, often made of fine wool or patterned silk. Favoured in the Eastern lands, it speaks of warmth and respectable station.";
}
