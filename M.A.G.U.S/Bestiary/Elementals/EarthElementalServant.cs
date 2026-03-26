using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Elementals;

public sealed class EarthElementalServant : ElementalServant
{
    public EarthElementalServant()
    {
        AttackValue = 20;
        DefenseValue = 100;
        InitiateValue = 65;

        HealthPoints = 14;
        ExperiencePoints = 320;
    }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(3)]
    public override int GetDamage() => DiceThrow._2D6() + 3;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 70)];

    public override string Name => "Servant Earth Elemental";
}