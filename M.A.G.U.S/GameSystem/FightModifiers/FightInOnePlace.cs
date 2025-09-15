using M.A.G.U.S.GameSystem.FightModifier;

namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightInOnePlace : IFightModifier
{
    public short InitiatingValue => -20;

    public short AttackingValue => -15;

    public short DefendingValue => -5;

    public short AimingValue => 0;
}
