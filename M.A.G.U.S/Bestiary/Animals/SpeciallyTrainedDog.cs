using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class SpeciallyTrainedDog : DogBase
{
    public SpeciallyTrainedDog()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Small;

        AttackValue = 25;
        DefenseValue = 55;
        InitiateValue = 10;

        HealthPoints = 14;
        PainTolerancePoints = 30;

        PoisonResistance = 3;

        Intelligence = Enums.Intelligence.Low;
        ExperiencePoints = 6;

        ApplyBreedModifier();
    }

    public override string Name => "Specially trained dog";

    public override string[] Images => ["aeternam.png", "blegront.png", "cirnecos.png", "dog_common.png", "hastin.png", "pittaros.png", "robardoar.png"];

    [DiceThrow(ThrowType._1D5)]
    public override int GetDamage() => Math.Max(0, DiceThrow._1D5() + breedModifier.ExtraDamage);

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 130)];
}