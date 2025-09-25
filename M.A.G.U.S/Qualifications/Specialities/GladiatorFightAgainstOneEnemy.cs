using M.A.G.U.S.GameSystem.FightModifier;
using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class GladiatorFightAgainstOneEnemy : SpecialQualification, IFightModifier
{
    public short InitiatingValue => 5;

    public short AttackingValue => 5;

    public short DefendingValue => 10;

    public short AimingValue => 0;

    public override string Name => "Combat modifiers against one enemy";
}
