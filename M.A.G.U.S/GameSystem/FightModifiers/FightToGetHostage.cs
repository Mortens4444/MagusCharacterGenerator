namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightToGetHostage : IFightModifier
{
    public int InitiatingValue => -5;

    public int AttackValue => -5;

    public int DefenseValue => -15;

    public int? AimingValue => 0;
}
