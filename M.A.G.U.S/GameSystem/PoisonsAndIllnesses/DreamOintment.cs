using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class DreamOintment : Poison
{
    public override string Name => "Dream Ointment";

    public override Money Price => new(0, 3);
}
