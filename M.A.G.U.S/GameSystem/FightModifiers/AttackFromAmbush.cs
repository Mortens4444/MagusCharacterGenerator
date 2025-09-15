using M.A.G.U.S.GameSystem.FightModifier;

namespace M.A.G.U.S.GameSystem.FightModifiers;

public class AttackFromAmbush : IFightModifier
{
    public short InitiatingValue => short.MaxValue;

    public short AttackingValue => 30;

    public short DefendingValue => 0;

    public short AimingValue => 10;
}
