using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Demons;

public sealed class Dralyor : Creature
{
    public Dralyor()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.CursedLand;

        AttackValue = 90; // 65;
        DefenseValue = 130;
        InitiateValue = 25;

        HealthPoints = 18;
        PainTolerancePoints = 60;

        AstralMagicResistance = 50;
        MentalMagicResistance = 50;
        PoisonResistance = 9;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 400;
    }

    public override double AttacksPerRound => 2;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 90)];
}