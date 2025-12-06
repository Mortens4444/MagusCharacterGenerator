namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightFromMovingHorse : IFightModifier
{
    public int InitiatingValue => 5;

    public int AttackingValue => 10;

    public int DefendingValue => 20;

    public int AimingValue => -20;
}
