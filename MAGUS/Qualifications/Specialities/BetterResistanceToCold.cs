using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class BetterResistanceToCold(int resistanceModifier) : SpecialQualification
{
    public int ResistanceModifier { get; } = resistanceModifier;

    public override string Name => "Better resistance to cold";
}
