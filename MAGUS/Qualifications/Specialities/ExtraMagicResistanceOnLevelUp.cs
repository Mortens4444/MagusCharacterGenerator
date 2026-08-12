using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class ExtraMagicResistanceOnLevelUp(int extraResistancePoints) : SpecialQualification
{
    public int ExtraResistancePoints { get; } = extraResistancePoints;

    public override string Name => "Extra magical resistance / level";
}
