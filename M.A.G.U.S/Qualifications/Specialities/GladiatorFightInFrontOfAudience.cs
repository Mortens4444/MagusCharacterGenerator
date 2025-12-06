using M.A.G.U.S.GameSystem.FightModifiers;
using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class GladiatorFightInFrontOfAudience : SpecialQualification, IFightModifier
{
    public int InitiatingValue => 5;

    public int AttackingValue => 5;

    public int DefendingValue => 5;

    public int AimingValue => 0;

    public override string Name => "Combat modifiers with audience";
}
