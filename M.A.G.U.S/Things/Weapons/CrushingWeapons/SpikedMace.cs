using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class SpikedMace : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 7;

    public byte AttackingValue => 12;

    public byte DefendingValue => 13;

    public override double Weight => 2;

    public override Money Price => new(1);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(2)]
    public byte GetDamage() => (byte)(DiceThrow._1K6() + 2);

    public override string Name => "Spiked mace";

    public override string Description => "A ferocious mace whose head is covered entirely in sharp, piercing spikes. It both crushes and punctures, leaving grievous wounds even through heavy clothing.";
}