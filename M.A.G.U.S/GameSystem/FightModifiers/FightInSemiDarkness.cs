using M.A.G.U.S.GameSystem.FightModifier;

namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightInSemiDarkness : IFightModifier
{
    public short InitiatingValue => -15;

    public short AttackingValue => -30;

    public short DefendingValue => -35;

    public short AimingValue => -70;
}
