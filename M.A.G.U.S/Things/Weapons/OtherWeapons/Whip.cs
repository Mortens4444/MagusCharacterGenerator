using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.OtherWeapons;

public class Whip : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 3;

    public byte AttackingValue => 6;

    public byte DefendingValue => 0;

    public override double Weight => 0.6;

    public override Money Price => new(0, 1);

    [DiceThrow(ThrowType._1D2)]
    public byte GetDamage() => (byte)DiceThrow._1D2();

    public override string Description => "A long, flexible strip of leather, used to lash and sting the target. While it lacks killing power, it can distract, disarm, or inflict great pain.";
}