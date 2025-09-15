using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Things.StabbingWeapons;

public class MaraSequor : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 7;

    public byte AttackingValue => 16;

    public byte DefendingValue => 14;

    public double Weight => 1;

    public Money Price => new(2);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(2)]
    public byte GetDamage() => (byte)(DiceThrow._2K6() + 2);

    public override string Name => "Mara-sequor";
}