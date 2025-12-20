namespace M.A.G.U.S.GameSystem.CombatModifiers;

public interface ICombatModifier
{
    int InitiateValue { get; }

    int AttackValue { get; }

    int DefenseValue { get; }

    int AimValue { get; }
}
