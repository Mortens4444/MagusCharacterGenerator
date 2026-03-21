using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Gahul : LivingDead
{
    public Gahul()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 40;
        DefenseValue = 80;
        InitiateValue = 15;

        HealthPoints = 25;
        PoisonResistance = Int32.MaxValue;
        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 85;
        NecrographyDepartment = NecrographyDepartment.BloodDrinkingUndead;
    }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D6() + 2;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 60)];
}