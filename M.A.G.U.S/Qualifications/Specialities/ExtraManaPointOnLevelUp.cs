using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class ExtraManaPointOnLevelUp(int extraPoints) : SpecialQualification
{
    public int ExtraManaPoints { get; } = extraPoints;
    
    public override string Name => "Extra Mana points/level";
}
