using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class LizardCreature : Creature
{
    public LizardCreature()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        AttackValue = 60;
        DefenseValue = 100;
        InitiateValue = 25;
        AimValue = 30;
        HealthPoints = 15;
        PainTolerancePoints = 55;
        AstralMagicResistance = 22;
        MentalMagicResistance = 22;
        PoisonResistance = 5;
        Intelligence = Enums.Intelligence.Average;
        Alignment = Enums.Alignment.OrderDeath;
        ExperiencePoints = 180;
    }

    public override string Name => "Lizard creature (Snil-doh)";

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D6() + 2;

    [DiceThrow(ThrowType._4D10)]
    public override int GetNumberAppearing() => DiceThrow._4D10();

    public override string[] Images => ["lizard_creature"];

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 70), new Speed(TravelMode.InWater, 70)];
}
