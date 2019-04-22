using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Battle
{
    class TwoHandedCombat : Qualification
    {
        public TwoHandedCombat(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
            : base(qualificationLevel,  level)
        {
        }

        public override string ToString() => Lng.Elem("Two-handed combat");
    }
}
