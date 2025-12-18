namespace M.A.G.U.S.GameSystem.FightModifiers;

public class AttackFromAmbush : IFightModifier
{
    public int InitiatingValue => Int16.MaxValue;

    public int AttackValue => 30;

    public int DefenseValue => 0;

    public int? AimingValue => 10;
}
