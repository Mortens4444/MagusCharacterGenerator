using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.StabbingWeapons;

public class Dagger : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 2;

    public override int InitiateValue => 10;

    public int AttackValue => 8;

    public int DefenseValue => 2;

    public override double Weight => 0.3;

    public override Money Price => new(0, 1);

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override string Description => "A short, sharp blade used as a tool, a last defense, or for a silent, sudden attack. Easily concealed and often carried as a secondary weapon.";
}