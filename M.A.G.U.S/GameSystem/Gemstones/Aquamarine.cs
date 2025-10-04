﻿using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Aquamarine : Gemstone
{
    public Aquamarine() : base("elementals (primordial water)") { }

    public override Money Price => new Money(50);
}