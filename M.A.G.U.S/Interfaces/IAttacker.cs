namespace M.A.G.U.S.Interfaces;

public interface IAttacker
{
    int InitiatingBaseValue { get; }

    int AttackingBaseValue { get; }

    int DefendingBaseValue { get; }

    int AimingBaseValue { get; }
}
