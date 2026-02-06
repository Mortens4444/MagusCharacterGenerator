using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class MetalMirror : Thing
{
	public override string Name => "Metal mirror";

	public override Money Price => new(0, 0, 10);

    public override string Description => "A small, polished sheet of bronze or steel used to reflect the visage. Though the image is often blurred, it suffices for necessary grooming.";
}
