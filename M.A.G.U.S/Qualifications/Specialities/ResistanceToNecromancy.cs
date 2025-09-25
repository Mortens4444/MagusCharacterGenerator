using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class ResistanceToNecromancy : SpecialQualification
{
    public sbyte ResistanceToMagicModifier { get; }

    public override string Name => "Resistance to necromancy";

    public ResistanceToNecromancy(sbyte resistanceToMagicModifier)
    {
        ResistanceToMagicModifier = resistanceToMagicModifier;
    }
}
