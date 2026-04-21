using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.BreedModifiers;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Models;
using Mtf.Extensions.Services;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class HuntingDog : DogBase
{
    public HuntingDog()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Small;

        AttackValue = 45;
        DefenseValue = 75;
        InitiateValue = 18;

        HealthPoints = 15;
        PainTolerancePoints = 42;

        PoisonResistance = 4;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 15;

        ApplyBreedModifier();
    }

    public override string Name => "Hunting dog";

    public override string[] Images => ["dog_hunting.png"];

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => Math.Max(0, DiceThrow._1D6() + breedModifier.ExtraDamage);

    [DiceThrow(ThrowType._1D3)]
    public override int GetNumberAppearing() => DiceThrow._1D3();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 140)];
}