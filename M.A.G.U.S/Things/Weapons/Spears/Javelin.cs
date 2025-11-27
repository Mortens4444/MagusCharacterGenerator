using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.Spears;

public class Javelin : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 8;

    public byte AttackingValue => 13;

    public byte DefendingValue => 5;

    public override double Weight => 1.5;

    public override Money Price => new(0, 5);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(1)]
    public byte GetDamage() => (byte)(DiceThrow._1K6() + 1);

    public override string Name => "Spear/javelin";

    public override string Description => "A light, slender throwing spear designed to be cast at the foe before closing to melee. Easily carried in a sheaf and effective against unarmoured targets.";
}