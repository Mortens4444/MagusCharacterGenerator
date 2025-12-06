using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class SpikedMace : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public int InitiatingValue => 7;

    public int AttackingValue => 12;

    public int DefendingValue => 13;

    public override double Weight => 2;

    public override Money Price => new(1);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D6() + 2;

    public override string Name => "Spiked mace";

    public override string Description => "A ferocious mace whose head is covered entirely in sharp, piercing spikes. It both crushes and punctures, leaving grievous wounds even through heavy clothing.";
}