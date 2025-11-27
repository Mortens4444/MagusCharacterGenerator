using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class BackpackSmall : Thing
{
	public override string Name => "Backpack, small";

	public override Money Price => new(0, 0, 90);

    public override string Description => "A humble, manageable pack for carrying necessities such as rations, a waterskin, and perhaps a small blanket. Suitable for short travels or daily labour.";
}
