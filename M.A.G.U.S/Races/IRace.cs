using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Qualifications;

namespace M.A.G.U.S.Races;

public interface IRace : IAbilities
{
    string Name { get; }

    QualificationList Qualifications { get; }

    List<PercentQualification> PercentQualifications { get; }

    SpecialQualificationList SpecialQualifications { get; }
}
