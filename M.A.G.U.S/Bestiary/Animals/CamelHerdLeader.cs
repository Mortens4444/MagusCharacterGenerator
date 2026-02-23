using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class CamelHerdLeader : Creature
{
    public CamelHerdLeader()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Big;
        AttackValue = 12;
        DefenseValue = 55;
        InitiateValue = 7;
        MinHealthPoints = 20;
        MaxHealthPoints = 30;
        MinPainTolerancePoints = 30;
        MaxPainTolerancePoints = 35;
        PoisonResistance = 4;
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 4;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D2)]
    public override int GetNumberAppearing() => DiceThrow._1D10();

    public override string Name => "Camel bull";

    public override string[] Images => ["camel.png"];

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 130)];
}
