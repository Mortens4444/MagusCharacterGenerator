using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.GameSystem.Psi;

public interface IPsi
{
    PsiKind PsiKind { get; }

    int BaseQualificationLevel { get; }

    int MasterQualificationLevel { get; }

    QualificationLevel QualificationLevel { get; }
}
