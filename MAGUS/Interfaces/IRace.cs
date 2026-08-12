using MAGUS.Enums;
using MAGUS.Interfaces;
using MAGUS.Qualifications;

namespace MAGUS.Races;

public interface IRace : IAbilities
{
    string Name { get; }

    QualificationList Qualifications { get; }

    PercentQualificationList PercentQualifications { get; }

    SpecialQualificationList SpecialQualifications { get; }

    string GenerateCharacterName();

    Alignment? Alignment { get; }

    Size Size { get; }
}
