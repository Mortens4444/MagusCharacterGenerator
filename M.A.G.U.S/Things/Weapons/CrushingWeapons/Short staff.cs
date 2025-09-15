using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class Shortstaff : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 9;

    public byte AttackingValue => 9;

    public byte DefendingValue => 17;

    public double Weight => 0.7;

    public Money Price => new(0, 0, 30);

    [DiceThrow(ThrowType._1K3)]
    public byte GetDamage() => (byte)DiceThrow._1K3();

    public override string Name => "Short staff";
}