using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.Spears;

public class Halberd : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1 / 2;

    public byte InitiatingValue => 1;

    public byte AttackingValue => 14;

    public byte DefendingValue => 15;

    public override double Weight => 3;

    public override Money Price => new(5);

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(2)]
    public byte GetDamage() => (byte)(DiceThrow._2D6() + 2);

    public override string Description => "A versatile polearm featuring an axe blade for chopping, a sharp spike for thrusting, and a hook for dismounting riders. The weapon of elite city guards.";
}