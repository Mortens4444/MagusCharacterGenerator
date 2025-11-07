namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightAsDizzily : IFightModifier
{
    public short InitiatingValue => -15;

    public short AttackingValue => -20;

    public short DefendingValue => -25;

    public short AimingValue => -30;
}
