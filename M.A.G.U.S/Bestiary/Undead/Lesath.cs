using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Lesath : LivingDead
{
    public Lesath()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 40;
        DefenseValue = 80;
        InitiateValue = 20;
        AimValue = 0;

        HealthPoints = 30;
        PainTolerancePoints = 60;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Outstanding;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 0;
        NecrographyDepartment = NecrographyDepartment.SpiritFeedingOnVitality;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}