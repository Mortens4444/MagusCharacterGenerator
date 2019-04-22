using MagusCharacterGenerator.GameSystem.Psi;
using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Scientific.Psi
{
    class PsiSlanWay : Qualification, IPsi
    {
        public PsiSlanWay()
            : base(QualificationLevel.Master, 1)
        {
        }

        public PsiKind PsiKind => PsiKind.Slan;

        public override string ToString() => Lng.Elem("Psi Slan-way");
    }
}
