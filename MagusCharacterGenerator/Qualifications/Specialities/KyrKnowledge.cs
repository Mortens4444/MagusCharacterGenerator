using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class KyrKnowledge : ISpecialQualification
    {
        public KyrKnowledge()
        {
			// +1 Pszi pont/szint
			// +1 Mp/szint
        }

        public override string ToString() => Lng.Elem("Kyr knowledge");
    }
}
