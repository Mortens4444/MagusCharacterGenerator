using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Bestiary.Demons;

public sealed class Sytix : Creature
{
    public Sytix()
    {
        Occurrence = Occurrence.Summoned;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 110; //95
        DefenseValue = 150; //190
        InitiateValue = 65;

        HealthPoints = 50;
        PainTolerancePoints = 110;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Psi = new PsiPyarron();
        PsiPoints = 11;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 16000;
    }

    public override string Name => "Sytix (the Destroyer)";

    public override string[] Images => ["sytix.png"];

    public override double AttacksPerRound => 9;

    [DiceThrow(ThrowType._5D6)]
    public override int GetDamage() => DiceThrow._5D6(); //1D6() + 8

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 250)];
}