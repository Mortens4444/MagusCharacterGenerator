using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.OtherWeapons;

public class DefendingDagger : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 8;

    public byte AttackingValue => 4;

    public byte DefendingValue => 19;

    public double Weight => 0.3;

    public Money Price => new(0, 2);

    [DiceThrow(ThrowType._1K6)]
    public byte GetDamage() => (byte)DiceThrow._1K6();

    public override string Name => "Defending dagger";
}