using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class GoodInitiator(byte initiatingBase) : SpecialQualification
	{
    public byte InitiatingBase { get; } = initiatingBase;
}
