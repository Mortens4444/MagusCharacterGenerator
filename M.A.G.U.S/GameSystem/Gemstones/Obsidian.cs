using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Obsidian : Gemstone
{
    public Obsidian() : base("necromancy") { }

    public override Money Price => new Money(3);
}