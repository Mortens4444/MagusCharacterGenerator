using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class GoodInitiator(int InitiateBase) : SpecialQualification
{
    public int InitiateBase { get; } = InitiateBase;
}
