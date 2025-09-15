using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Things.StabbingWeapons;

public class SlanStar : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 3;

    public byte InitiatingValue => 10;

    public byte AttackingValue => 4;

    public byte DefendingValue => 4;

    public double Weight => 0.1;

    public Money Price => new(0, 0, 40);

    [DiceThrow(ThrowType._1K3)]
    public byte GetDamage() => (byte)DiceThrow._1K3();

    public override string Name => "Slan star";
}