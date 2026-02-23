using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class KirSiss : Creature
{
    public KirSiss()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        AttackValue = 25;
        DefenseValue = 60;
        InitiateValue = 5;
        HealthPoints = 5;
        PainTolerancePoints = 20;
        PoisonResistance = 5;
        AstralMagicResistance = 70;
        MentalMagicResistance = 60;
        Intelligence = Enums.Intelligence.High;
        ExperiencePoints = 600;
    }

    [DiceThrowModifier(0)]
    public override int GetDamage() => 0;

    [DiceThrow(ThrowType._1D5)]
    public override int GetNumberAppearing() => DiceThrow._1D5();

    public override string Name => "Kir-siss";

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 50)];
}
