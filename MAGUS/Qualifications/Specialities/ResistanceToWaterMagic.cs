using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class ResistanceToWaterMagic(int resistanceToMagicModifier) : SpecialQualification
{
    public int ResistanceToMagicModifier { get; } = resistanceToMagicModifier;
    
    public override string Name => "Resistance to water magic";
}
