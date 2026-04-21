using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class WildDog : DogBase
{
    public WildDog()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;

        AttackValue = 30;
        DefenseValue = 60;
        InitiateValue = 10;

        HealthPoints = 16;
        PainTolerancePoints = 38;

        PoisonResistance = 5;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 7;

        ApplyBreedModifier();
    }

    public override string Name => "Wild dog";

    public override string[] Images => ["wild_dog.png"];

    [DiceThrow(ThrowType._1D6)]
    //[DiceThrowModifier(breedModifierType.ExtraDamage)] // FIXME - maybe forget Reflection based implementation and creaet SourceCodeGenerator which generates partial classes?
    public override int GetDamage() => Math.Max(0, DiceThrow._1D6() + breedModifier.ExtraDamage);

    [DiceThrow(ThrowType._2D10)]
    public override int GetNumberAppearing() => DiceThrow._2D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 130)];
}