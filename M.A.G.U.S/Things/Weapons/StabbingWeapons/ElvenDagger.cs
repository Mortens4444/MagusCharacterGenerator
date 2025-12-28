using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class ElvenDagger : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 2;

    public int InitiateValue => 9;

    public int AttackValue => 9;

    public int DefenseValue => 2;

    public override double Weight => 0.2;

    public override Money Price => new(5);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D6() + 1;

    public override string Name => "Elven dagger";

    public override string Description => "A slender, beautifully crafted dagger of Elven make, known for its keen edge and fine balance, often bearing magical properties.";
}