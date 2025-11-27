using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class BootsWalking : Thing
{
	public override string Name => "Boots, walking";

	public override Money Price => new(0, 0, 80);

    public override string Description => "Practical, comfortable boots crafted for extended travel on foot. They possess thick, reliable soles and require regular care with grease and oil.";
}
