using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.GameSystem.Psi
{
	public interface IPsi
    {
        PsiKind PsiKind { get; }

        byte BaseQualificationLevel { get; }

        byte MasterQualificationLevel { get; }

        QualificationLevel QualificationLevel { get; }
    }
}
