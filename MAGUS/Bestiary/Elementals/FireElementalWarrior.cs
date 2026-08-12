using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;

namespace MAGUS.Bestiary.Elementals;

public sealed class FireElementalWarrior : ElementalWarrior
{
    public FireElementalWarrior()
    {
        AttackValue = 45;
        DefenseValue = 115;
        InitiateValue = 95;

        HealthPoints = 26;
        ExperiencePoints = 680;

        Intelligence = Enums.Intelligence.Low;
    }

    [DiceThrow(ThrowType._3D10)]
    public override int GetDamage() => DiceThrow._3D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 80)];

    public override string Name => "Warrior Fire Elemental";
}