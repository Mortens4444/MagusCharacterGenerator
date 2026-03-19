using M.A.G.U.S.Bestiary.Undead;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Magical;

public sealed class Aberration : LivingDead
{
    public Aberration()
    {
        Occurrence = Occurrence.Summoned;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 40;
        DefenseValue = 80;
        InitiateValue = 20;

        HealthPoints = 15;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Low;

        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 65;
    }

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 80)];
}