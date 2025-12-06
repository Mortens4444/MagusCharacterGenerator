using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class GoodInitiator(int initiatingBase) : SpecialQualification
{
    public int InitiatingBase { get; } = initiatingBase;
}
