using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;

namespace MAGUS.Bestiary.Elementals;

public sealed class WaterElementalWarrior : ElementalWarrior
{
    public WaterElementalWarrior()
    {
        AttackValue = 25;
        DefenseValue = 105;
        InitiateValue = 75;

        HealthPoints = 24;
        ExperiencePoints = 620;
    }

    [DiceThrow(ThrowType._3D6)]
    public override int GetDamage() => DiceThrow._3D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 45), new Speed(TravelMode.InWater, 85)];

    public override string Name => "Warrior Water Elemental";
}