using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Whistle : Thing
{
	public override Money Price => new(0, 2, 0);

    public override string Description => "A small tube of wood or bone used to produce a sharp, loud sound. Used to signal others over long distances or to call a dog.";
}
