using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class HeadhunterSword : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 8;

    public byte AttackingValue => 16;

    public byte DefendingValue => 16;

    public override double Weight => 0.8;

    public override Money Price => new(2);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(2)]
    public byte GetDamage() => (byte)(DiceThrow._1K6() + 2);

    public override string Name => "Assassin’s sword";
}