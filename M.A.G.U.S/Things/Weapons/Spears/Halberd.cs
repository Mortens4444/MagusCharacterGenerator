using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.Spears;

public class Halberd : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1.0 / 2;

    public override int InitiateValue => 1;

    public int AttackValue => 14;

    public int DefenseValue => 15;

    public override double Weight => 3;

    public override Money Price => new(5);

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._2D6() + 2;

    public override string Description => "A versatile polearm featuring an axe blade for chopping, a sharp spike for thrusting, and a hook for dismounting riders. The weapon of elite city guards.";
}