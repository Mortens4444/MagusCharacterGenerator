using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Things.StabbingWeapons;

public class ShadlekianMace : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 8;

    public byte AttackingValue => 13;

    public byte DefendingValue => 14;

    public double Weight => 1.8;

    public Money Price => new(1, 3);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(1)]
    public byte GetDamage() => (byte)(DiceThrow._1K6() + 1);

    public override string Name => "Shadlekian mace";
}