using M.A.G.U.S.GameSystem.FightModifier;

namespace M.A.G.U.S.GameSystem.FightModifiers;

public class Charge : IFightModifier
{
    public short InitiatingValue => 0;

    public short AttackingValue => 20;

    public short DefendingValue => -25;

    public short AimingValue => -30;
}
