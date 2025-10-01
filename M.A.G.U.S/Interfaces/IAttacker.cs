namespace M.A.G.U.S.Interfaces;

public interface IAttacker
{
    byte InitiatingBaseValue { get; }

    byte AttackingBaseValue { get; }

    byte DefendingBaseValue { get; }

    byte AimingBaseValue { get; }
}
