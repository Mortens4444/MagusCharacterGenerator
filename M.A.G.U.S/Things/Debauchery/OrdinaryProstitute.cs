using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Debauchery;

public class OrdinaryProstitute : Thing
{
	public override string Name => "Common prostitute";

	public override Money Price => new(0, 3, 0);

    public override string Description => "A woman of low standing and little protection, offering her services in the taverns and back alleys of the city for meagre coin. Her life is often harsh and transient, yet she holds a vast knowledge of local gossip, secrets, and the comings and goings of the populace.";
}
