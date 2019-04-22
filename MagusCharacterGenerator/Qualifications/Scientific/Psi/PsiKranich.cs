using MagusCharacterGenerator.GameSystem.Psi;
using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Scientific.Psi
{
    class PsiKranich : Qualification, IPsi
    {
        public PsiKranich(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
            : base(qualificationLevel, level)
        {
        }

        public PsiKind PsiKind => PsiKind.Kranich;

        public override string ToString() => Lng.Elem("Psi Kranich");
    }
}
