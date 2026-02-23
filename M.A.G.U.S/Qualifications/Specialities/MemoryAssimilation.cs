using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public sealed class MemoryAssimilation(int resistanceTarget, int rounds) : SpecialQualification
{
    public int ResistanceTarget { get; } = resistanceTarget;

    public int Rounds { get; } = rounds;

    public override string Name => "Memory Assimilation";
}
