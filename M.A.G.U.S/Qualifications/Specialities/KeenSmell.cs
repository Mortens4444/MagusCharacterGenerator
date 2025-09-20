﻿using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class KeenSmell(double multiplier) : SpecialQualification
{
    public double Multiplier { get; } = multiplier;

    public override string Name => "Keen smell";
}
