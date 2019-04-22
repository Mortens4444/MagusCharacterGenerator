using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Race
{
    interface IRace : IAbilities
    {
        QualificationList Qualifications { get; }

        List<PercentQualification> PercentQualifications { get; }

        SpecialQualificationList SpecialQualifications { get; }
    }
}
