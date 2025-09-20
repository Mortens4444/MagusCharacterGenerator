using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Things.StabbingWeapons;

public class JannSaber : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 9;

    public byte AttackingValue => 20;

    public byte DefendingValue => 17;

    public double Weight => 120;

    public override Money Price => new(0, 5);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(3)]
    public byte GetDamage() => (byte)(DiceThrow._1K6() + 3);

    public override string Name => "Sword, jann sabre";
}