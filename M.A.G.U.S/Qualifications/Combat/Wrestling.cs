﻿using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class Wrestling(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
	: Qualification(qualificationLevel, level)
{
    public override byte QpToBaseQualification => 8;

    public override byte QpToMasterQualification => 15;
}
