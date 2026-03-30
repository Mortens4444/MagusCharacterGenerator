using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class Mermaid : Creature
{
    public Mermaid()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Water;

        AttackValue = 15;
        DefenseValue = 65;
        InitiateValue = 25;

        HealthPoints = 7;
        PainTolerancePoints = 25;

        AstralMagicResistance = 45;
        MentalMagicResistance = 35;
        PoisonResistance = 5;

        ManaPoints = 40 + DiceThrow._3D10();

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.LifeChaos;

        ExperiencePoints = 200;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetDamage() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.InWater, 80), new Speed(TravelMode.OnLand, 100)];
}