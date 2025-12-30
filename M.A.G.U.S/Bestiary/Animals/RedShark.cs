using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class RedShark : Creature
{
    public RedShark()
    {
        Occurrence = Occurrence.Rare;
        Intelligence = Enums.Intelligence.Animal;
        Size = Size.Up_to_3_meters;
        InitiateValue = 40;
        AttackValue = 70;
        DefenseValue = 100;
        HealthPoints = 20;
        PainTolerancePoints = 40;
        PoisonResistance = 5;
        ExperiencePoints = 35;
    }

    public override string Name => "Red shark";

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();


    [DiceThrow(ThrowType._1D10)]
    public override int GetNumberAppearing() => DiceThrow._1D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.InWater, 180)];
}
