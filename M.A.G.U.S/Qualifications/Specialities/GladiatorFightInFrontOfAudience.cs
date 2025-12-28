using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Qualifications.Specialities;

public class GladiatorFightInFrontOfAudience : SpecialQualification, ICombatModifier
{
    public int InitiateValue => 5;

    public int AttackValue => 5;

    public int DefenseValue => 5;

    public int AimValue => 0;

    public override string Name => "Combat modifiers with audience";
}
