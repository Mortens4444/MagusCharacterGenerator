namespace M.A.G.U.S.GameSystem.FightModifier;

public interface IFightModifier
{
    short InitiatingValue { get; }

    short AttackingValue { get; }

    short DefendingValue { get; }

    short AimingValue { get; }
}
