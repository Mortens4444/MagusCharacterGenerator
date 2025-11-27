using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class SlanSword : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 8;

    public byte AttackingValue => 20;

    public byte DefendingValue => 12;

    public override double Weight => 1.4;

    public override Money Price => new(100);

    [DiceThrow(ThrowType._1K10)]
    public byte GetDamage() => (byte)(DiceThrow._1K10() + 2);

    public override string Name => "Slan sword";

    public override string Description => "A full-sized, ritualistic or combat sword used by the Slan cultists, likely bearing disturbing symbols or unconventional, wicked geometry.";
}