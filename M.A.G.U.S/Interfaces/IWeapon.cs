﻿using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Interfaces;

public interface IWeapon
{
    double AttacksPerRound { get; }

    byte InitiatingValue { get; }

    double Weight { get; }

    Money Price { get; }

    byte GetDamage();
}
