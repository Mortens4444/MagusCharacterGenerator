using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class Galleon : Thing
{
	public override Money Price => new(1800, 0, 0);

    public override string Description => "A large, multi-decked sailing ship with towering masts. Built for long voyages, war, and the transport of vast amounts of valuable cargo across the great oceans.";
}
