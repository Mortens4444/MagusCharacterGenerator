using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class ExtraMagicResistanceOnLevelUp(int extraResistancePoints) : SpecialQualification
{
    public int ExtraResistancePoints { get; } = extraResistancePoints;

    public override string Name => "Extra magical resistance / level";
}
