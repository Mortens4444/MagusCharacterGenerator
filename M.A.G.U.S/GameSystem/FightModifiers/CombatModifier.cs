namespace M.A.G.U.S.GameSystem.FightModifiers;

public sealed class CombatModifier : ICombatModifier
{
    public int InitiateValue { get; set; }

    public int AttackValue { get; set; }

    public int DefenseValue { get; set; }

    public int AimValue { get; set; }

    public int CombatModifierPoints { get; set; }
}
