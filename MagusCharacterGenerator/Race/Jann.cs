using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Scientific.Psi;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Race
{
	class Jann : Race
    {
        public override short Intelligence => 2;

        public override QualificationList Qualifications => new QualificationList
        {
            new PsiPyarron(QualificationLevel.Master)
        };

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new ExtraPsiPointOnLevelUp(1),
			new UseWizardMentalMosaicAsPsi()

		};

        public override string ToString()
        {
            return Lng.Elem("Jann");
        }
    }
}
