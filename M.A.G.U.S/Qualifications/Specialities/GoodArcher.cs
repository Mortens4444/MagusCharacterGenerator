using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class GoodArcher(byte aimingBase) : SpecialQualification
{
    public byte AimingBase { get; } = aimingBase;
}
