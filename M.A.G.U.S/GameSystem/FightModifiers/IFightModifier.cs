namespace M.A.G.U.S.GameSystem.FightModifiers;

public interface IFightModifier
{
    short InitiatingValue { get; }

    short AttackingValue { get; }

    short DefendingValue { get; }

    short AimingValue { get; }
}
