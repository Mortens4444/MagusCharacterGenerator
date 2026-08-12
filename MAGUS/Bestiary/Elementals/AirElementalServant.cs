using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;

namespace MAGUS.Bestiary.Elementals;

public sealed class AirElementalServant : ElementalServant
{
    public AirElementalServant()
    {
        AttackValue = 55;
        DefenseValue = 110;
        InitiateValue = 85;

        HealthPoints = 9;
        ExperiencePoints = 310;
    }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D6() + 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 100)];

    public override string Name => "Servant Air Elemental";
}