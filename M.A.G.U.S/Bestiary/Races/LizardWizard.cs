using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class LizardWizard : Creature
{
    public LizardWizard()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        Speed = 70;
        AttackValue = 64;
        DefenseValue = 108;
        InitiatingValue = 35;
        AttacksPerRound = 3;
        HealthPoints = 18;
        PainTolerancePoints = 70;
        AstralMagicResistance = 42;
        MentalMagicResistance = 39;
        PoisonResistance = 5;
        Psi = new PsiKyrMethod();
        PsiPoints = 80;
        ManaPoints = 100;
        Intelligence = Intelligence.Outstanding;
        Alignment = Enums.Alignment.OrderDeath;
        ExperiencePoints = 7000;
    }

    public override string Name => "Lizard wizard";

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(4)]
    public override byte GetDamage() => (byte)(DiceThrow._2D6() + 4);

    public override byte GetNumberAppearing() => 1;
}
