using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class TwoHandedMace : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1 / 2;

    public byte InitiatingValue => 0;

    public byte AttackingValue => 7;

    public byte DefendingValue => 6;

    public double Weight => 3;

    public override Money Price => new(1, 2);

    [DiceThrow(ThrowType._3K6)]
    public byte GetDamage() => (byte)DiceThrow._3K6();

    public override string Name => "Two-handed mace";
}