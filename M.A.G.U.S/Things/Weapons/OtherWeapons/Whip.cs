using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.OtherWeapons;

public class Whip : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 2;

    public override int InitiateValue => 3;

    public int AttackValue => 6;

    public int DefenseValue => 0;

    public override double Weight => 0.6;

    public override Money Price => new(0, 1);

    [DiceThrow(ThrowType._1D2)]
    public override int GetDamage() => DiceThrow._1D2();

    public override string Description => "A long, flexible strip of leather, used to lash and sting the target. While it lacks killing power, it can distract, disarm, or inflict great pain.";
}