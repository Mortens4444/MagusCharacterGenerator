using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Elementals;

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