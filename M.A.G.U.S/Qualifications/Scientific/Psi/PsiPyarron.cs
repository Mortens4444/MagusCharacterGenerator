﻿using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific.Psi;

public class PsiPyarron(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel, level), IPsi
{
    public PsiKind PsiKind => PsiKind.Pyarron;

    public override string Name => "Psi, Pyarron";

    public override byte QpToBaseQualification => 10;

    public override byte QpToMasterQualification => 55;
}
