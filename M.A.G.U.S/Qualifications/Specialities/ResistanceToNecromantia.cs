using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class ResistanceToNecromantia : SpecialQualification
{
    public sbyte ResistanceToMagicModifier { get; }

    public ResistanceToNecromantia(sbyte resistanceToMagicModifier)
    {
        ResistanceToMagicModifier = resistanceToMagicModifier;
    }
}
