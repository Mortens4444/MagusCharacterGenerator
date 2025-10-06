using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Things.StabbingWeapons;

public class TwoHandedHatchet : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1 / 2;

    public byte InitiatingValue => 0;

    public byte AttackingValue => 8;

    public byte DefendingValue => 6;

    public override double Weight => 5;

    public override Money Price => new(2);

    [DiceThrow(ThrowType._3K6)]
    public byte GetDamage() => (byte)DiceThrow._3K6();

    public override string Name => "Two-handed axe";
}