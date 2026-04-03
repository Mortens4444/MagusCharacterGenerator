using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Bestiary.Demons;

public sealed class Shereb : Creature
{
    public Shereb()
    {
        Occurrence = Occurrence.Summoned;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 105;
        DefenseValue = 145;
        InitiateValue = 50;

        HealthPoints = 35;
        PainTolerancePoints = 75;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Psi = new PsiPyarron();
        PsiPoints = 7;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 1250;
    }

    public override string Name => "Shereb (the Soldier)";

    public override string[] Images => ["shereb.png"];

    [DiceThrow(ThrowType._3D6)]
    [DiceThrowModifier(6)]
    public override int GetDamage() => DiceThrow._3D6() + 6;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 300)];
}