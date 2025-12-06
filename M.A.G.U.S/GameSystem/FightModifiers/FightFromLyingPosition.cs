namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightFromLyingPosition : IFightModifier
{
    public int InitiatingValue => -20;

    public int AttackingValue => -15;

    public int DefendingValue => -5;

    public int AimingValue => 0;
}
