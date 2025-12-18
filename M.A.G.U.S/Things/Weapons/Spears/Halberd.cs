using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.Spears;

public class Halberd : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1 / 2;

    public int InitiatingValue => 1;

    public int AttackingValue => 14;

    public int DefendingValue => 15;

    public override double Weight => 3;

    public override Money Price => new(5);

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._2D6() + 2;

    public override string Description => "A versatile polearm featuring an axe blade for chopping, a sharp spike for thrusting, and a hook for dismounting riders. The weapon of elite city guards.";
}