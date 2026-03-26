using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Eleidin : Creature
{
    public Eleidin()
    {
        Occurrence = Occurrence.VeryRare;
        PlacesOfOccurrence = TerrainType.CursedLand | TerrainType.Volcano | TerrainType.LavaLake | TerrainType.Geyser;
        Size = Size.Human;

        AttackValue = 25;
        DefenseValue = 90;
        InitiateValue = 15;
        AimValue = 45;

        HealthPoints = 9;
        PainTolerancePoints = 75;

        AstralMagicResistance = 25;
        MentalMagicResistance = 25;
        PoisonResistance = 10; // 6

        ManaPoints = 90;

        Intelligence = Enums.Intelligence.Outstanding;
        Alignment = Alignment.Order;
        ExperiencePoints = 5650;
    }

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    [DiceThrow(ThrowType._1D3)]
    public override int GetNumberAppearing() => /*Random.Shared.Next(2) == 0 ? 1 :*/ DiceThrow._1D3();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 110)];
}