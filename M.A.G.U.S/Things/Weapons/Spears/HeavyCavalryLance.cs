using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.Spears;

public class HeavyCavalryLance : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1 / 3;

    public byte InitiatingValue => 0;

    public byte AttackingValue => 16;

    public byte DefendingValue => 0;

    public override double Weight => 5;

    public override Money Price => new(1, 5);

    [DiceThrow(ThrowType._2D10)]
    public byte GetDamage() => (byte)(DiceThrow._2D10());

    public override string Name => "Heavy cavalry lance";

    public override string Description => "A thick, reinforced lance designed for the heaviest armoured knights on the largest warhorses. The shaft is often protected by a vamplate near the grip.";
}