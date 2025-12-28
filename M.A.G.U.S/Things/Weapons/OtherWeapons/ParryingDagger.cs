using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.OtherWeapons;

public class ParryingDagger : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 2;

    public int InitiateValue => 8;

    public int AttackValue => 4;

    public int DefenseValue => 19;

    public override double Weight => 0.3;

    public override Money Price => new(0, 2);

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override string Name => "Parrying dagger";

    public override string Description => "A sturdy, often broad-bladed dagger held in the off-hand, used primarily to deflect and catch enemy blades during a sword fight.";
}