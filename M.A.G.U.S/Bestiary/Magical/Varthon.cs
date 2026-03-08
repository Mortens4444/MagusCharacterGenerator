using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Magical;

public sealed class Varthon : Creature
{
    public Varthon()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 60;
        DefenseValue = 80;
        InitiateValue = 10;

        AttacksPerRound = 2;

        HealthPoints = 25;
        PainTolerancePoints = 80;

        AstralMagicResistance = 10;
        MentalMagicResistance = 10;
        PoisonResistance = 8;

        Intelligence = Enums.Intelligence.Animal;

        ExperiencePoints = 80;
    }

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 50),
        new Speed(TravelMode.InTheAir, 120)
    ];
}