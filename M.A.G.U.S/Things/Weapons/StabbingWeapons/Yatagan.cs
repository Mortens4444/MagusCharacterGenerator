using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class Yatagan : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public int InitiateValue => 7;

    public int AttackValue => 14;

    public int DefenseValue => 14;

    public override double Weight => 0.8;

    public override Money Price => new(1, 4);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D6() + 2;

    public override string Name => "Sword, yataghan";

    public override string Description => "A curved, single-edged sword with a distinctive flared tip, common in Eastern armies. Designed for powerful, deep cutting strokes.";
}