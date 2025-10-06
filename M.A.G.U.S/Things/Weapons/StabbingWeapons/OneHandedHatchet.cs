using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Things.StabbingWeapons;

public class OneHandedHatchet : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 5;

    public byte AttackingValue => 12;

    public byte DefendingValue => 11;

    public override double Weight => 2;

    public override Money Price => new(0, 6);

    [DiceThrow(ThrowType._1K10)]
    public byte GetDamage() => (byte)DiceThrow._1K10();

    public override string Name => "One-handed axe";
}