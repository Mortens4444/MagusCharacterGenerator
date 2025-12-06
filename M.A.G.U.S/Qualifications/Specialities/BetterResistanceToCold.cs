using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class BetterResistanceToCold(int resistanceModifier) : SpecialQualification
{
    public int ResistanceModifier { get; } = resistanceModifier;

    public override string Name => "Better resistance to cold";
}
