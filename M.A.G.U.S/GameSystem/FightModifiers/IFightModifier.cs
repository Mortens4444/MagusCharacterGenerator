namespace M.A.G.U.S.GameSystem.FightModifiers;

public interface IFightModifier
{
    int InitiatingValue { get; }

    int AttackValue { get; }

    int DefenseValue { get; }

    int? AimingValue { get; }
}
