using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class ResistanceToNecromancy(int resistanceToMagicModifier) : SpecialQualification
{
    public int ResistanceToMagicModifier { get; } = resistanceToMagicModifier;

    public override string Name => ResistanceToMagicModifier < 0 ? "Weak necromantic resistance" : "Strong necromantic resistance";
}
