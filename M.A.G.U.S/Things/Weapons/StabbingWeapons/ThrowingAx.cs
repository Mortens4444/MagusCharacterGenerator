using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class ThrowingAx : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 2;

    public int InitiatingValue => 9;

    public int AttackingValue => 10;

    public int DefendingValue => 4;

    public override double Weight => 1.2;

    public override Money Price => new(0, 1);

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override string Name => "Throwing axe";

    public override string Description => "A small, balanced axe designed to be hurled at the enemy before engaging in melee, often used to soften the enemy line or distract a foe.";
}