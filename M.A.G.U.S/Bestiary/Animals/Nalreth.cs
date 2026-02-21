using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Armors;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Nalreth : Creature
{
    public Nalreth()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size._7_to_11_meters;
        InitiateValue = 55;
        //AttackValue = 0;
        DefenseValue = 50;
        AimValue = 35;
        HealthPoints = 35;
        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = 7;
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 300;
        Armor = new NaturalArmor(3);
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(5)]
    public override int GetNumberAppearing() => DiceThrow._1D10() + 5;

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 120), new Speed(TravelMode.OnLand, 30)];
}
