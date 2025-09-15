using M.A.G.U.S.GameSystem.FightModifier;

namespace M.A.G.U.S.GameSystem.FightModifiers;

public class AttackFromHalfBehind : IFightModifier
{
    public short InitiatingValue => 2;

    public short AttackingValue => 5;

    public short DefendingValue => 0;

    public short AimingValue => 0;
}
