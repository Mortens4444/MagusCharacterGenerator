using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class LapisLazuli : Gemstone
{
    public LapisLazuli() : base("psyche, mind") { }

    public override string Name => "Lapis Lazuli";

    public override Money Price => new(2);
}