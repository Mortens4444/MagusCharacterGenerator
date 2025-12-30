using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class DemonShark : Creature
{
    public DemonShark()
    {
        Occurrence = Occurrence.Rare;
        Intelligence = Enums.Intelligence.Animal;
        Size = Size._6_to_8_meters;
        InitiateValue = 40;
        AttackValue = 100;
        DefenseValue = 140;
        HealthPoints = 35;
        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = 8;
        ExperiencePoints = 95;
    }

    public override string Name => "Demon shark";

    [DiceThrow(ThrowType._2D10)]
    [DiceThrowModifier(5)]
    public override int GetDamage() => DiceThrow._2D10() + 5;


    [DiceThrow(ThrowType._1D10)]
    public override int GetNumberAppearing() => DiceThrow._1D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.InWater, 185)];
}
