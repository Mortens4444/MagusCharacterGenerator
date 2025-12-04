using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class ShortSword : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 9;

    public byte AttackingValue => 12;

    public byte DefendingValue => 14;

    public override double Weight => 1;

    public override Money Price => new(1);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public byte GetDamage() => (byte)(DiceThrow._1D6() + 1);

    public override string Name => "Short sword";

    public override string Description => "A sturdy, reliable sword with a short, wide blade. Excellent for fighting in close quarters, such as in ruins, dense forests, or on a crowded ship deck.";
}