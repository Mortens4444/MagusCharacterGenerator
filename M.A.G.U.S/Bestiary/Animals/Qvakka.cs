using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Qvakka : Creature
{
    public Qvakka()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Small;
        AttackValue = 40;
        DefenseValue = 75;
        InitiateValue = 20;
        HealthPoints = 5;
        PainTolerancePoints = 9;
        PoisonResistance = 2;
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 4;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._20_To_70)]
    public override int GetNumberAppearing() => DiceThrow.Range(20, 70);

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 80)];
}
