using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class ExtraManaPointOnLevelUp(int extraPoints) : SpecialQualification
{
    public int ExtraManaPoints { get; } = extraPoints;
    
    public override string Name => "Extra Mana points/level";
}
