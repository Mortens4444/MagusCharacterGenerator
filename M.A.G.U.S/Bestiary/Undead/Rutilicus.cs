using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Rutilicus : LivingDead
{
    public Rutilicus()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 50;
        DefenseValue = 70;
        InitiateValue = 15;

        HealthPoints = 18;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.ChaosDeath;

        ExperiencePoints = 80;
        NecrographyDepartment = NecrographyDepartment.Ghost;
    }

    public override string Name => "Plague Wraith (Rutilicus)";

    public override string[] Images => ["rutilicus.png"];

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6(); // + disease effect // only PTP

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 160)];
}