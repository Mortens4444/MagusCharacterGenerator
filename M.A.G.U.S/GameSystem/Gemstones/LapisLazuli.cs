﻿using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class LapisLazuli : Gemstone
{
    public LapisLazuli() : base("psyche, mind") { }

    public override string Name => "Lapis Lazuli";

    public override Money Price => new Money(2);
}