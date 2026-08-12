using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Qualifications.Scientific.Psi;

namespace MAGUS.Bestiary.Races;

public sealed class LizardWizard : Creature
{
    public LizardWizard()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Riverbank | TerrainType.Plains;

        AttackValue = 64;
        DefenseValue = 108;
        InitiateValue = 35;
        
        HealthPoints = 18;
        PainTolerancePoints = 70;

        AstralMagicResistance = 42;
        MentalMagicResistance = 39;
        PoisonResistance = 5;

        Psi = new PsiKyrMethod();
        PsiPoints = 80;
        ManaPoints = 100;

        Intelligence = Enums.Intelligence.Outstanding;
        Alignment = Alignment.OrderDeath;
        ExperiencePoints = 7000;
    }

    public override string Name => "Lizard wizard (Snil-veh)";

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(4)]
    public override int GetDamage() => DiceThrow._2D6() + 4;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override string[] Images => ["lizard_wizard.png"];

    public override double AttacksPerRound => 3;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 70), new Speed(TravelMode.InWater, 70)];
}
