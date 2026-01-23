using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific.Psi;

public class PsiKyrMethod() : Qualification(QualificationLevel.Master, 1), IPsi
{

    public PsiKind PsiKind => PsiKind.Kyr;

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 55;

    public override string Name => "Psi, Kyr method";

    public override string[] Images => ["psi.png"];
}
