using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class SoulDevourer : Creature
{
    public SoulDevourer()
    {
        Occurrence = Occurrence.Summoned;
        Size = Size.Human;
        Alignment = Alignment.Chaos;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 60;
        DefenseValue = 110;
        InitiateValue = 40;

        HealthPoints = 12;

        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Average;
        ExperiencePoints = 800;

        // AstralMagicResistance = special;
        // Damage = special;
    }

    public override string Name => "Soul devourer";

    [DiceThrowModifier(0)]
    public override int GetDamage() => 0; // Special

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.InTheAir, 200)
    ];
}
