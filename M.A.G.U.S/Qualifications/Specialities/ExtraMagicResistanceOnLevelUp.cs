using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class ExtraMagicResistanceOnLevelUp(byte extraResistancePoints) : SpecialQualification
{
    public byte ExtraResistancePoints { get; } = extraResistancePoints;

    public override string Name => "Extra magical resistance / level";
}
