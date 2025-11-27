using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class SealingWax : Thing
{
	public override string Name => "Sealing wax";

	public override Money Price => new(0, 0, 10);

    public override string Description => "A stick of coloured, melted wax used to seal letters or documents. Once stamped with a signet, it proves the authenticity of the sender.";
}
