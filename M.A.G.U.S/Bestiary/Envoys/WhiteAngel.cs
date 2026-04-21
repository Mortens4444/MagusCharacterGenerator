using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Things.Armors;

namespace M.A.G.U.S.Bestiary.Envoys;

public sealed class WhiteAngel : Creature
{
    public WhiteAngel()
    {
        Armor = new NaturalArmor(9);
        PlacesOfOccurrence = TerrainType.Anywhere;
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        Alignment = Alignment.OrderLife;

        AttackValue = 113;
        DefenseValue = 180;
        InitiateValue = 52;

        AttacksPerRound = 2;

        HealthPoints = 30;
        PainTolerancePoints = 160;

        AstralMagicResistance = 135;
        MentalMagicResistance = 135;
        PoisonResistance = Int32.MaxValue;

        Psi = new PsiPyarron();
        PsiPoints = 50;
        ManaPoints = 108;

        Intelligence = Enums.Intelligence.Outstanding;
        ExperiencePoints = 15000;
    }

    public override string Name => "White angel";

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int GetDamage() => DiceThrow._2D6() + 8;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public Deity God => Deity.Domvik;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 120), new Speed(TravelMode.InTheAir, 150)];
}