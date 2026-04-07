using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Morrona : Creature
{
    public Morrona()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Small;

        AttackValue = 75;
        DefenseValue = 95;
        InitiateValue = 35;

        HealthPoints = 4;
        PainTolerancePoints = 35;

        AstralMagicResistance = 3;
        PoisonResistance = 5;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 220;
    }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D6() + 1;

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetNumberAppearing() => DiceThrow._1D6() + 2;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 10)];
}