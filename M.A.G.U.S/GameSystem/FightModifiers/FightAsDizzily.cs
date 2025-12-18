namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightAsDizzily : IFightModifier
{
    public int InitiatingValue => -15;

    public int AttackValue => -20;

    public int DefenseValue => -25;

    public int? AimingValue => -30;
}
