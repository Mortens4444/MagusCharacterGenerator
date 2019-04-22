using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.GameSystem.Psi
{
    interface IPsi
    {
        PsiKind PsiKind { get; }

        byte BaseQualificationLevel { get; }

        byte MasterQualificationLevel { get; }

        QualificationLevel QualificationLevel { get; }
    }
}
