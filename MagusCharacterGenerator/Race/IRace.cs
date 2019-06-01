using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.Qualifications;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Race
{
	public interface IRace : IAbilities
    {
        QualificationList Qualifications { get; }

        List<PercentQualification> PercentQualifications { get; }

        SpecialQualificationList SpecialQualifications { get; }
    }
}
