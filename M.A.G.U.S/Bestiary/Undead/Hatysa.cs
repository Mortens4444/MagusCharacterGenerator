using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Hatysa : LivingDead
{
    public Hatysa()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 95;
        DefenseValue = 80;
        InitiateValue = 32;

        HealthPoints = 35;
        PoisonResistance = Int32.MaxValue;
        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 1500;
        NecrographyDepartment = NecrographyDepartment.SpiritFeedingOnVitality;
    }

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}