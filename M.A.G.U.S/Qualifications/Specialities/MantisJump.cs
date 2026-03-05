using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public sealed class MantisJump(int forwardMeters, int upwardMeters) : SpecialQualification
{
    public int ForwardMeters { get; } = forwardMeters;

    public int UpwardMeters { get; } = upwardMeters;

    public override string Name => "Mantis jump";

    public override string ToString() => $" ({ForwardMeters}m ⇒, {UpwardMeters}m ⇑)";
}