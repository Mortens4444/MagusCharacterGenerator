using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Elementals;

public sealed class EarthElementalWarrior : Elemental
{
    public EarthElementalWarrior()
    {
        AttackValue = 35;
        DefenseValue = 120;
        InitiateValue = 75;

        HealthPoints = 26;
        ExperiencePoints = 680;
    }

    [DiceThrow(ThrowType._2D10)]
    [DiceThrowModifier(5)]
    public override int GetDamage() => DiceThrow._2D10() + 5;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 60)];

    public override string Name => "Warrior Earth Elemental";
}