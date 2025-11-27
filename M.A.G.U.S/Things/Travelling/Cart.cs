using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class Cart : Thing
{
	public override Money Price => new(0, 0, 150);

    public override string Description => "A simple, two-wheeled vehicle drawn by a single horse, mule, or ox. Used by common folk for transporting goods and burdens short distances over poor roads.";
}
