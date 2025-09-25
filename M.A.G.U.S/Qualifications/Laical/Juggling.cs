﻿using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class Juggling(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel, level)
{
    public override byte QpToBaseQualification => 3;

    public override byte QpToMasterQualification => 10;
}
