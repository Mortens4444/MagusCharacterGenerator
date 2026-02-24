using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Coronella : Creature
{
    public Coronella()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;

        AttackValue = 40;
        DefenseValue = 60;
        InitiateValue = 25;
        AimValue = 0;

        HealthPoints = 18;
        PainTolerancePoints = 57;

        PoisonResistance = 6;
        AstralMagicResistance = 0;
        MentalMagicResistance = 0;

        Intelligence = Enums.Intelligence.Animal;

        ExperiencePoints = 70;
    }

    public override string Name => "Coronella (sand ray)";

    public override string[] Images => ["coronella.png"];

    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6(); // + poison

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.InTheAir, 120),
        new Speed(TravelMode.Underground, 10)
    ];
}