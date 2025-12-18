using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class ShortSword : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public int InitiatingValue => 9;

    public int AttackingValue => 12;

    public int DefendingValue => 14;

    public override double Weight => 1;

    public override Money Price => new(1);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D6() + 1;

    public override string Name => "Short sword";

    public override string Description => "A sturdy, reliable sword with a short, wide blade. Excellent for fighting in close quarters, such as in ruins, dense forests, or on a crowded ship deck.";
}