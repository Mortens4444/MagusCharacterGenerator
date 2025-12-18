namespace M.A.G.U.S.GameSystem.FightModifiers;

public interface ICombatModifier
{
    int InitiateValue { get; }

    int AttackValue { get; }

    int DefenseValue { get; }

    int AimValue { get; }
}
