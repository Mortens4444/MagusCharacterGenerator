using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class Cow : Thing
{
    public override Money Price => new(0, 8, 0);

    public override string Description => "The common beast of the fields, prized for its milk, hide, and eventual meat. They are slow, sturdy, and essential for the sustenance of any village or fortress.";
}
