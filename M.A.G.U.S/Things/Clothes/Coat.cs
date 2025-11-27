using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class Coat : Thing
{
	public override Money Price => new(0, 2, 0);

    public override string Description => "A heavy, outer garment, providing substantial protection against the cold. Typically made of thick wool and often reaching below the knee.";
}
