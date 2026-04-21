using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Zauder : Creature
{
    public Zauder()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 60; // változó
        DefenseValue = 120; // változó
        InitiateValue = 35; // változó

        HealthPoints = 25;
        PainTolerancePoints = 80;

        PoisonResistance = Int32.MaxValue;
        AstralMagicResistance = 60;
        MentalMagicResistance = 80;

        Intelligence = Enums.Intelligence.Outstanding;

        ExperiencePoints = 100; // változó

        Alignment = Alignment.ChaosDeath;
    }

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D10() + 2; // változó

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 90) /* változó */];
}