using MAGUS.GameSystem.Qualifications;

namespace MAGUS.GameSystem.Psi;

public interface IPsi
{
    PsiKind PsiKind { get; }

    int BaseQualificationLevel { get; }

    int MasterQualificationLevel { get; }

    QualificationLevel QualificationLevel { get; }
}
