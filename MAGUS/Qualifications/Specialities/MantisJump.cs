using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public sealed class MantisJump(int forwardMeters, int upwardMeters) : SpecialQualification
{
    public int ForwardMeters { get; } = forwardMeters;

    public int UpwardMeters { get; } = upwardMeters;

    public override string Name => "Mantis jump";

    public override string ToString() => $" ({ForwardMeters}m ⇒, {UpwardMeters}m ⇑)";
}