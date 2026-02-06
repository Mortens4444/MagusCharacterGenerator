using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class AlBahraKahrem : Poison
{
    public override string Name => "Al Bahra-kahrem (The Death Dance)";

    public override string[] Images => ["al_bahra_kahrem.png"];

    public override Money Price => new(5);
}
