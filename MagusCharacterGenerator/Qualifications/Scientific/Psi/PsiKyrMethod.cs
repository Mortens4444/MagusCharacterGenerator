using MagusCharacterGenerator.GameSystem.Psi;
using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Scientific.Psi
{
    class PsiKyrMethod : Qualification, IPsi
    {
        public PsiKyrMethod()
            : base(QualificationLevel.Master, 1)
        {
        }

        public PsiKind PsiKind => PsiKind.Kyr;

        public override string ToString() => Lng.Elem("Psi Kyr method");
    }
}
