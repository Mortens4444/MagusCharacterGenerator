using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class GlovesNoble : Thing
{
	public override string Name => "Gloves, noble";

	public override Money Price => new(0, 3, 0);

    public override string Description => "Fine, soft leather gloves worn by the gentry. They protect the hands from the cold while offering a refined appearance; some are trimmed with velvet or embroidery.";
}
