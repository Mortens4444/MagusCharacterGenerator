using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class Tunic : Thing
{
	public override Money Price => new(0, 3, 0);

    public override string Description => "The basic, loose-fitting shirt worn by most folk, reaching from the shoulder to the thigh or knee. It is the foundation of most common attire.";
}
