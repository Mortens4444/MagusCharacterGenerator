using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;

namespace MAGUS.Bestiary.Elementals;

public sealed class AirElementalWarrior : ElementalWarrior
{
    public AirElementalWarrior()
    {
        AttackValue = 75;
        DefenseValue = 130;
        InitiateValue = 105;

        HealthPoints = 16;
        ExperiencePoints = 620;
    }

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 120)];

    public override string Name => "Warrior Air Elemental";
}