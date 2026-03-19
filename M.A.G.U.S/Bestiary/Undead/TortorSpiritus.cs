using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class TortorSpiritus : LivingDead
{
    public TortorSpiritus()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 60;
        DefenseValue = 40;
        InitiateValue = 10;

        HealthPoints = 20;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Average;

        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 80;

        NecrographyDepartment = NecrographyDepartment.Ghost;
    }

    public override string Name => "Tortor spiritus";

    public override string[] Images => ["tortor_spiritus.pmg"];

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10(); // Only PTP

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 160)];
}