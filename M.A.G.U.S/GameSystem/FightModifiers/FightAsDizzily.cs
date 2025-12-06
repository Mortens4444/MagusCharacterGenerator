namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightAsDizzily : IFightModifier
{
    public int InitiatingValue => -15;

    public int AttackingValue => -20;

    public int DefendingValue => -25;

    public int AimingValue => -30;
}
