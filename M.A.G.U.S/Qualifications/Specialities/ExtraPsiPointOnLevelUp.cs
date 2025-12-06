using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class ExtraPsiPointOnLevelUp(int extraPoints) : SpecialQualification
{
    public int ExtraPoints { get; } = extraPoints;
    
    public override string Name => "Extra Psi points/level";
}
