using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class CarvedClub : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 2;

    public byte AttackingValue => 7;

    public byte DefendingValue => 14;

    public double Weight => 1.3;

    public Money Price => Money.Free;

    [DiceThrow(ThrowType._1K6)]
    public byte GetDamage() => (byte)DiceThrow._1K6();

    public override string Name => "Carved club";
}