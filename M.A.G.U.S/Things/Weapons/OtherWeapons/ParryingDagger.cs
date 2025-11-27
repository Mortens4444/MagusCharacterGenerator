using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.OtherWeapons;

public class ParryingDagger : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 8;

    public byte AttackingValue => 4;

    public byte DefendingValue => 19;

    public override double Weight => 0.3;

    public override Money Price => new(0, 2);

    [DiceThrow(ThrowType._1K6)]
    public byte GetDamage() => (byte)DiceThrow._1K6();

    public override string Name => "Parrying dagger";

    public override string Description => "A sturdy, often broad-bladed dagger held in the off-hand, used primarily to deflect and catch enemy blades during a sword fight.";
}