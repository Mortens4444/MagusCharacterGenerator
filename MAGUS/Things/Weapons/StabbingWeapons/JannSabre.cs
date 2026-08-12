using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.StabbingWeapons;

public class JannSabre : Weapon, IMeleeWeapon // Csak Dzsenn veheti meg
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 9;

    public int AttackValue => 20;

    public int DefenseValue => 17;

    public override double Weight => 0.5;

    public override Money Price => new(120);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(3)]
    public override int GetDamage() => DiceThrow._1D6() + 3;

    public override string Name => "Sword, jann sabre";

    public override string Description => "A long, elegantly curved sabre used by the Jann desert warriors. Its balance and edge are optimized for deadly sweeping cuts from horseback.";
}