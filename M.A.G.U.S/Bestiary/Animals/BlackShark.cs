using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class BlackShark : Creature
{
    public BlackShark()
    {
        Occurrence = Occurrence.Rare;
        Intelligence = Enums.Intelligence.Animal;
        Size = Size._4_to_6_meters;
        InitiateValue = 45;
        AttackValue = 85;
        DefenseValue = 95;
        HealthPoints = 20;
        PainTolerancePoints = 55;
        AstralMagicResistance = 0;
        MentalMagicResistance = 0;
        PoisonResistance = 6;
        ExperiencePoints = 55;
    }

    public override string Name => "Black shark";

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D10() + 2;


    [DiceThrow(ThrowType._1D10)]
    public override int GetNumberAppearing() => DiceThrow._1D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.InWater, 175)];
}
