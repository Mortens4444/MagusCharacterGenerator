using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class LongStaff : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 4;

    public byte AttackingValue => 10;

    public byte DefendingValue => 16;

    public double Weight => 1.2;

    public Money Price => new(0, 0, 50);

    [DiceThrow(ThrowType._1K5)]
    public byte GetDamage() => (byte)DiceThrow._1K5();

    public override string Name => "Long staff";
}