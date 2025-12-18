namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightFromLyingPosition : IFightModifier
{
    public int InitiatingValue => -20;

    public int AttackValue => -15;

    public int DefenseValue => -5;

    public int? AimingValue => 0;
}
