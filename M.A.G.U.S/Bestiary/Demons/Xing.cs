using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Bestiary.Demons;

public sealed class Xing : Creature
{
    public Xing()
    {
        Occurrence = Occurrence.Summoned;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 110;
        DefenseValue = 150;
        InitiateValue = 65;

        HealthPoints = 75;
        PainTolerancePoints = 125;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Psi = new PsiSlanWay();
        PsiPoints = 12;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 35000;
    }

    public override string Name => "Xing (the Deathbringer)";

    public override string[] Images => ["xing.png"];

    public override double AttacksPerRound => 4;

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(12)]
    public override int GetDamage() => DiceThrow._2D6() + 12;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}
