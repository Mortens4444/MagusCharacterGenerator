namespace M.A.G.U.S.GameSystem.FightModifiers;

public interface IFightModifier
{
    int InitiatingValue { get; }

    int AttackingValue { get; }

    int DefendingValue { get; }

    int AimingValue { get; }
}
