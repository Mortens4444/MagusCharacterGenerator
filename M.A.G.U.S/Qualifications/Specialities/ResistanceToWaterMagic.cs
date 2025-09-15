using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class ResistanceToWaterMagic(sbyte resistanceToMagicModifier) : SpecialQualification
{
    public sbyte ResistanceToMagicModifier { get; } = resistanceToMagicModifier;
}
