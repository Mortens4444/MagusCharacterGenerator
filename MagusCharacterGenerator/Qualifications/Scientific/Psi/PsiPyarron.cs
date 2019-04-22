using MagusCharacterGenerator.GameSystem.Psi;
using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Scientific.Psi
{
    class PsiPyarron : Qualification, IPsi
    {
        public PsiPyarron(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
            : base(qualificationLevel, level)
        {
        }

        public PsiKind PsiKind => PsiKind.Pyarron;

        public override string ToString() => Lng.Elem("Psi Pyarron");
    }
}
