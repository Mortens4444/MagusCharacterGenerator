using M.A.G.U.S.GameSystem.FightModifier;

namespace M.A.G.U.S.GameSystem.FightModifiers;

public class AttackFromBehind : IFightModifier
{
    public short InitiatingValue => 5;

    public short AttackingValue => 10;

    public short DefendingValue => 0;

    public short AimingValue => 0;
}
