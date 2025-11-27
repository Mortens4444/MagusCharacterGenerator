using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class Mule : Thing
{
	public override Money Price => new(0, 8, 0);

    public override string Description => "A steril hybrid of a horse and a donkey. It combines the strength and sure-footedness of both parents, making it an excellent, sturdy choice for long-distance trading or military supplies.";
}
