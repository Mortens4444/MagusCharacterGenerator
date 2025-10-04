using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class ExtraManaPointOnLevelUp(byte extraPoints) : SpecialQualification
{
    public byte ExtraManaPoints { get; } = extraPoints;
    
    public override string Name => "Extra Mana points/level";
}
