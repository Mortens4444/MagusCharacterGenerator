using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class DreamThief : LivingDead
{
    public DreamThief()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 0;
        DefenseValue = 80;
        InitiateValue = 15;

        HealthPoints = 20;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.Chaos;
        ExperiencePoints = 1000;

        NecrographyDepartment = NecrographyDepartment.Ghost;
    }

    public override string Name => "Dream thief";

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrowModifier(0)]
    public override int GetDamage() => 0;

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 150)];
}