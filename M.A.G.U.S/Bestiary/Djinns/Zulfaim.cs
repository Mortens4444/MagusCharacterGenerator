using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Bestiary.Djinns;

public sealed class Zulfaim : DjinnCreature
{
    public Zulfaim()
    {
        Occurrence = Occurrence.Summoned;
        Alignment = Alignment.Life;

        AttackValue = 150;
        DefenseValue = 200;
        InitiateValue = 80;
        AimValue = 65;

        AttacksPerRound = 2;

        HealthPoints = 38;
        PainTolerancePoints = 139;

        Psi = new PsiPyarron();
        PsiPoints = 150;
        ManaPoints = 150;

        Intelligence = Enums.Intelligence.Outstanding;
        ExperiencePoints = 60000;
    }

    public override string Name => "Djinn Prince - Zulfaim (Kahra Fellahma)";

    public override string[] Images => ["zulfaim.png"];

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(12)]
    public override int GetDamage() => DiceThrow._2D6() + 12;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 140), new Speed(TravelMode.InTheAir, 200)];
}