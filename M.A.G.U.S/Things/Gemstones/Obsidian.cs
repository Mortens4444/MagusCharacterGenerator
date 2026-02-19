using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Obsidian : Gemstone
{
    public override Money Price => new(3);

    public override string Description => "necromancy";
}