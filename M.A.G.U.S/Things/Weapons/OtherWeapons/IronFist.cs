using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.OtherWeapons;

public class IronFist : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 2;

    public int InitiatingValue => 9;

    public int AttackingValue => 5;

    public int DefendingValue => 2;

    public override double Weight => 0.2;

    public override Money Price => new(0, 1);

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    public override string Name => "Iron fist (knuckle)";

    public override string Description => "A heavy gauntlet or fist-wrap of iron, designed to greatly augment the damage done by a punch, capable of shattering a jaw or cracking a rib.";
}