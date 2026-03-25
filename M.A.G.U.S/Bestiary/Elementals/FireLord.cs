using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Elementals;

public sealed class FireLord : ElementalLord
{
    public FireLord()
    {
        Size = Size.Big;

        AttackValue = 105;
        DefenseValue = 160;
        InitiateValue = 40;

        HealthPoints = 60;

        ExperiencePoints = 40000;
    }

    public override string Name => "Fire Lord";

    /// <summary>
    /// Longsword attack: 1D10 physical + 10D6 fire damage.
    /// </summary>
    [DiceThrow(ThrowType._1D10)]
    [DiceThrow(ThrowType._10D6)] // For residents of the primary material plane only
    public override int GetDamage() => DiceThrow._1D10() + DiceThrow._10D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 120)];
}