using M.A.G.U.S.GameSystem.FightModifiers;
using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class GladiatorFightInFrontOfAudience : SpecialQualification, IFightModifier
{
    public short InitiatingValue => 5;

    public short AttackingValue => 5;

    public short DefendingValue => 5;

    public short AimingValue => 0;

    public override string Name => "Combat modifiers with audience";
}
