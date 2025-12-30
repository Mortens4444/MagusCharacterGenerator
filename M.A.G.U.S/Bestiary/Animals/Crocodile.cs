using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Crocodile : Creature
{
    public Crocodile()
    {
        ArmorClass = 5;
        Occurrence = Occurrence.Rare;
        Size = Size._6_to_8_meters;
        AttackValue = 55;
        DefenseValue = 60;
        InitiateValue = 35;
        HealthPoints = 45;
        PainTolerancePoints = 90;
        PoisonResistance = 5;
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 200;
    }

    [DiceThrow(ThrowType._3D6)]
    public override int GetDamage() => DiceThrow._3D6();

    [DiceThrow(ThrowType._1D5)]
    public override int GetNumberAppearing() => DiceThrow._1D5();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 35), new Speed(TravelMode.InWater, 120)];
}
