using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class GoodInitiator(int InitiateBase) : SpecialQualification
{
    public int InitiateBase { get; } = InitiateBase;
}
