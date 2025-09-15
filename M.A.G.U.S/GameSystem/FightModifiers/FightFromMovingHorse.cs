using M.A.G.U.S.GameSystem.FightModifier;

namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightFromMovingHorse : IFightModifier
{
    public short InitiatingValue => 5;

    public short AttackingValue => 10;

    public short DefendingValue => 20;

    public short AimingValue => -20;
}
