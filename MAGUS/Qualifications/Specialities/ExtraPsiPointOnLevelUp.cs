using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class ExtraPsiPointOnLevelUp(int extraPoints) : SpecialQualification
{
    public int ExtraPoints { get; } = extraPoints;
    
    public override string Name => "Extra Psi points/level";
}
