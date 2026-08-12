using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;

namespace MAGUS.Bestiary.Elementals;

public sealed class FireElementalServant : ElementalServant
{
    public FireElementalServant()
    {
        AttackValue = 35;
        DefenseValue = 95;
        InitiateValue = 75;

        HealthPoints = 11;
        ExperiencePoints = 320;
    }

    [DiceThrow(ThrowType._3D6)]
    public override int GetDamage() => DiceThrow._3D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 70)];

    public override string Name => "Servant Fire Elemental";
}