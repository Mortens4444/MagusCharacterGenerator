﻿using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class ShieldUse(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
    : Qualification(qualificationLevel, level)
{
    public override string Name => "Shield use";

    public override byte QpToBaseQualification => 5;

    public override byte QpToMasterQualification => 30;
}
