using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public sealed class PriestSpellcasting(int minLevel, int maxLevel) : SpecialQualification
{
    public int MinLevel { get; } = minLevel;

    public int MaxLevel { get; } = maxLevel;

    public override string Name => $"Priest Spellcasting";
}
