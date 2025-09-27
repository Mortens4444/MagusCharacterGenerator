﻿using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class BlindFighting(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Blind fighting";

    public override byte QpToBaseQualification => 10;

    public override byte QpToMasterQualification => 30;
}
