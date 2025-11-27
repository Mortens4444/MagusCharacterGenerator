using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class Carriage : Thing
{
	public override Money Price => new(15, 0, 0);

    public override string Description => "A sturdy, four-wheeled vehicle with an enclosed cab, usually drawn by two or more horses. Reserved for the wealthy and nobility, providing protection from the elements during travel.";
}
