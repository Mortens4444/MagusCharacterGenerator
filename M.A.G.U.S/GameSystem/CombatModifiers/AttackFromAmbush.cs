namespace M.A.G.U.S.GameSystem.CombatModifiers;

public class AttackFromAmbush : ICombatModifier
{
    public int InitiateValue => Int16.MaxValue;

    public int AttackValue => 30;

    public int DefenseValue => 0;

    public int AimValue => 10;
}
