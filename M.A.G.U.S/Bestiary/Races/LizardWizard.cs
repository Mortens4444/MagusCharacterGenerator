using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class LizardWizard : Creature
{
    public LizardWizard()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
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
        Alignment = Enums.Alignment.OrderDeath;
        ExperiencePoints = 7000;
    }

    public override string Name => "Lizard wizard (Snil-veh)";

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(4)]
    public override int GetDamage() => DiceThrow._2D6() + 4;

    public override int GetNumberAppearing() => 1;

    public override string[] Images => ["lizard_wizard.png"];

    public override double AttacksPerRound => 3;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 70), new Speed(TravelMode.InWater, 70)];
}
