namespace M.A.G.U.S.GameSystem.FightModifiers;

public class AttackFromAmbush : IFightModifier
{
    public int InitiatingValue => Int16.MaxValue;

    public int AttackingValue => 30;

    public int DefendingValue => 0;

    public int AimingValue => 10;
}
