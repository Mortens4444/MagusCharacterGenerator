using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.BreedModifiers;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Models;
using Mtf.Extensions.Services;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class CommonDog : DogBase
{
    public CommonDog()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Small;

        AttackValue = 20;
        DefenseValue = 50;
        InitiateValue = 9;

        HealthPoints = 14;
        PainTolerancePoints = 32;

        PoisonResistance = 3;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 3;

        ApplyBreedModifier();
    }

    public override string Name => "Common dog";

    public override string[] Images => ["dog_common.png"];

    [DiceThrow(ThrowType._1D5)]
    public override int GetDamage() => Math.Max(0, DiceThrow._1D5() + breedModifier.ExtraDamage);

    [DiceThrow(ThrowType._1D10)]
    public override int GetNumberAppearing() => DiceThrow._1D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 120)];
}