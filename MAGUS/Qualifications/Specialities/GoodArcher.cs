using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class GoodArcher(int aimingBase) : SpecialQualification
{
    public int AimBase { get; } = aimingBase;

    public override string Name => "Good archer";
}
