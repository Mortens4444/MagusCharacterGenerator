using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public sealed class MadnessSong(int resistanceTarget, int focusedRounds) : SpecialQualification
{
    public int ResistanceTarget { get; } = resistanceTarget;

    public int FocusedRounds { get; } = focusedRounds;

    public override string Name => "Madness Song";
}