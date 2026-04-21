using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Rackla : Creature
{
    public Rackla()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Cave;
        Country = GameSystem.Places.Country.Tarin;

        AttackValue = 35;
        DefenseValue = 50; // 80 levegőben
        InitiateValue = 15;

        HealthPoints = 8;
        PainTolerancePoints = 15;

        PoisonResistance = 7;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 13;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D2)]
    public override int GetNumberAppearing() => DiceThrow._1D2();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 50), new Speed(TravelMode.InTheAir, 110)];
}