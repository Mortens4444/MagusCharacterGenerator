namespace M.A.G.U.S.GameSystem.FightModifiers;

public class DefendingFight : IFightModifier
{
    public short InitiatingValue => short.MinValue;

    public short AttackingValue => 0;

    public short DefendingValue => 40;

    public short AimingValue => 0;
}
