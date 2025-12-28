using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.RangedWeapons;

public class ElvenBow : Weapon, IRangedWeapon
{
    public override double AttacksPerRound => 2;

    public int InitiateValue => 6;

    public int AimValue => 10;

    public int Distance => 120;

    public override double Weight => 0.7;

    public override Money Price => new(120);

    [DiceThrow(ThrowType._2D6_Ranged)]
    public override int GetDamage() => DiceThrow._2D6_RangedAttack();

    public override string Name => "Elven bow";

    public override string Description => "A beautifully crafted longbow made from rare, resilient woods. Its draw is light, yet its arrows fly further and with greater accuracy than common bows.";
}