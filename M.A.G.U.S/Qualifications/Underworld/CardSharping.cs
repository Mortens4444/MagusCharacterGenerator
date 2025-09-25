﻿using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Underworld;

public class CardSharping(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Card sharping";

    public override byte QpToBaseQualification => 10;

    public override byte QpToMasterQualification => 20;
}
