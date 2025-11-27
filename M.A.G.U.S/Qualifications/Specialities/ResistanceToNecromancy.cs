using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class ResistanceToNecromancy(sbyte resistanceToMagicModifier) : SpecialQualification
{
    public sbyte ResistanceToMagicModifier { get; } = resistanceToMagicModifier;

    public override string Name => resistanceToMagicModifier < 0 ? "Weak necromantic resistance" : "Strong necromantic resistance";
}
