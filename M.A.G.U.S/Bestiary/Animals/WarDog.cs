using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.BreedModifiers;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Models;
using Mtf.Extensions.Services;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class WarDog : DogBase
{
    public WarDog()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;

        AttackValue = 40;
        DefenseValue = 60;
        InitiateValue = 16;

        HealthPoints = 15;
        PainTolerancePoints = 44;

        PoisonResistance = 5;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 10;

        ApplyBreedModifier();
    }

    public override string Name => "War dog";

    public override string[] Images => ["dog_war.png"];

    public override double AttacksPerRound => 2;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => Math.Max(0, DiceThrow._1D6() + breedModifier.ExtraDamage);

    [DiceThrow(ThrowType._2D10)]
    public override int GetNumberAppearing() => DiceThrow._2D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 130)];
}