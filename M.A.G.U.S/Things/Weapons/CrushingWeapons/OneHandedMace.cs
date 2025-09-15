using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class OneHandedMace : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 7;

    public byte AttackingValue => 11;

    public byte DefendingValue => 12;

    public double Weight => 2;

    public Money Price => new(0, 8);

    [DiceThrow(ThrowType._1K6)]
    public byte GetDamage() => (byte)DiceThrow._1K6();

    public override string Name => "One-handed mace";
}