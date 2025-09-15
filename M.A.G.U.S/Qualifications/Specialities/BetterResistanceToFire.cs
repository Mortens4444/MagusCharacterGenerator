using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class BetterResistanceToFire(sbyte resistanceModifier) : SpecialQualification
{
    public sbyte ResistanceModifier { get; } = resistanceModifier;
}
