using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class GlovesFencing : Thing
{
	public override string Name => "Gloves, fencing";

	public override Money Price => new(0, 1, 0);

    public override string Description => "Thick leather gauntlets extending past the wrist, designed to protect the hands and forearm during martial practice or a duel with swords.";
}
