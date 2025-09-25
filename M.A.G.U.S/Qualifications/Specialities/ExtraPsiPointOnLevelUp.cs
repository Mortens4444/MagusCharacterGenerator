using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class ExtraPsiPointOnLevelUp(byte extraPoints) : SpecialQualification
{
    public byte ExtraPoints { get; } = extraPoints;
    
    public override string Name => "Extra Psi points/level";
}
