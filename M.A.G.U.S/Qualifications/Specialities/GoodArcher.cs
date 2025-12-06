using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class GoodArcher(int aimingBase) : SpecialQualification
{
    public int AimingBase { get; } = aimingBase;

    public override string Name => "Good archer";
}
