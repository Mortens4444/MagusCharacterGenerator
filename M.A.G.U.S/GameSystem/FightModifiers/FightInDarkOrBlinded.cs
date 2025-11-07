namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightInDarkOrBlinded : IFightModifier
{
    public short InitiatingValue => -20;

    public short AttackingValue => -60;

    public short DefendingValue => -70;

    public short AimingValue => -150;
}
