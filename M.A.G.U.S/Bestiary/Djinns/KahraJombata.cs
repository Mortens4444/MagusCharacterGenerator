using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Bestiary.Djinns;

public class KahraJombata : DjinnCreature
{
    public KahraJombata()
    {
        Occurrence = Occurrence.Summoned;
        Alignment = Alignment.Life;

        AttackValue = 200;
        DefenseValue = 250;
        InitiateValue = 100;
        AimValue = 80;

        AttacksPerRound = 4;

        HealthPoints = 64;
        PainTolerancePoints = 216;

        Psi = new PsiPyarron();
        PsiPoints = 200;
        ManaPoints = 200;

        Intelligence = Enums.Intelligence.Outstanding;
        ExperiencePoints = 200000;
    }

    public override string Name => "Djinn Great Ones - Kahra Jombata";

    public override string[] Images => ["kahra_jombata.png"];

    [DiceThrow(ThrowType._4D10)]
    [DiceThrowModifier(10)]
    public override int GetDamage() => DiceThrow._4D10() + 10;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 200), new Speed(TravelMode.InTheAir, 280)];
}
