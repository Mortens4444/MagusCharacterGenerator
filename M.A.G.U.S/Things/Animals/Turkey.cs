using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class Turkey : Thing
{
	public override string Name => "Turkey";

	public override Money Price => new(0, 0, 8);

    public override string Description => "A large, exotic bird from lands across the Great Sea. Prized for its substantial, dark meat, it is still somewhat rare and often reserved for great feasts and high tables.";
}
