using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Things.StabbingWeapons;

public class BastardSword : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 4;

    public byte AttackingValue => 13;

    public byte DefendingValue => 12;

    public double Weight => 2;

    public Money Price => new(2, 5);

    [DiceThrow(ThrowType._2K6)]
    public byte GetDamage() => (byte)DiceThrow._2K6();

    public override string Name => "Bastard sword";
}