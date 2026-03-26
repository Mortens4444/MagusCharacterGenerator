using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Elementals;

public sealed class WaterElementalServant : ElementalServant
{
    public WaterElementalServant()
    {
        AttackValue = 35;
        DefenseValue = 85;
        InitiateValue = 65;

        HealthPoints = 10;
        ExperiencePoints = 300;
    }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D10() + 2;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 55), new Speed(TravelMode.InWater, 90)];

    public override string Name => "Servant Water Elemental";
}