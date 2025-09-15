using M.A.G.U.S.GameSystem.FightModifier;

namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightToGetHostage : IFightModifier
{
    public short InitiatingValue => -5;

    public short AttackingValue => -5;

    public short DefendingValue => -15;

    public short AimingValue => 0;
}
