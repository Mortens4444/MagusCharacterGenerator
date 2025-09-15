﻿using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class PoisoningAndNeutralization : Qualification
{
    public PoisoningAndNeutralization(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
        : base(qualificationLevel, level)
    {
    }

    public override string Name => "Poisoning and neutralization";
}
