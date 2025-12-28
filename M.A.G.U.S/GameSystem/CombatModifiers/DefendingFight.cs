using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.GameSystem.CombatModifiers;

public class DefenseFight : ICombatModifier
{
    public int InitiateValue => int.MinValue;

    public int AttackValue => 0;

    public int DefenseValue => 40;

    public int AimValue => 0;
}
