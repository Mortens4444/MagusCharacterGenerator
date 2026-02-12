using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class ElDojjahJarem : Poison
{
    public override string Name => "El Dojjah Jarem (The Black Scorpion)";

    public override string[] Images => ["the_black_scorpion.png"];

    public override Money Price => new(15);
}
