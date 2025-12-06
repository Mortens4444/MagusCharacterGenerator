using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class Yatagan : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public int InitiatingValue => 7;

    public int AttackingValue => 14;

    public int DefendingValue => 14;

    public override double Weight => 0.8;

    public override Money Price => new(1, 4);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D6() + 2;

    public override string Name => "Sword, yataghan";

    public override string Description => "A curved, single-edged sword with a distinctive flared tip, common in Eastern armies. Designed for powerful, deep cutting strokes.";
}