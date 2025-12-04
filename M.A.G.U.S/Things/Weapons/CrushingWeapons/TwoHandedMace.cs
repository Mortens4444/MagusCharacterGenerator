using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class TwoHandedMace : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1 / 2;

    public byte InitiatingValue => 0;

    public byte AttackingValue => 7;

    public byte DefendingValue => 6;

    public override double Weight => 3;

    public override Money Price => new(1, 2);

    [DiceThrow(ThrowType._3D6)]
    public byte GetDamage() => (byte)DiceThrow._3D6();

    public override string Name => "Two-handed mace";

    public override string Description => "A massive, heavy mace requiring both hands to wield. Its blows can shatter stone and iron, making it the weapon of giants or highly trained, powerful champions.";
}