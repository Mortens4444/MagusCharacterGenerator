using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class ResistanceToWaterMagic(int resistanceToMagicModifier) : SpecialQualification
{
    public int ResistanceToMagicModifier { get; } = resistanceToMagicModifier;
    
    public override string Name => "Resistance to water magic";
}
