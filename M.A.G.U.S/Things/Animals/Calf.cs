using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class Calf : Thing
{
	public override Money Price => new(0, 5, 0);

    public override string Description => "A young bovine, still bound to its mother's side. Used primarily for its tender flesh and as a future source of milk and draught power. Easily startled and requires careful handling.";
}
