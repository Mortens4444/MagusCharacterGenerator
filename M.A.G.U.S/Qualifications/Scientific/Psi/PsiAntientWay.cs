using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Qualifications.Scientific.Psi;

public class PsiAntientWay(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IPsi, INotForLearn
{
    public PsiKind PsiKind => PsiKind.AntientWay;

    public override string Name => "Psi, Pyarron";

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 55;

    public override string[] Images => ["psi.png"];

    public PsiAntientWay() : this(QualificationLevel.Base) { }
}
