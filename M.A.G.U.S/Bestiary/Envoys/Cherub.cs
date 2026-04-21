using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Things.Armors;

namespace M.A.G.U.S.Bestiary.Envoys;

public sealed class Cherub : Creature
{
    public Cherub()
    {
        Armor = new NaturalArmor(11);
        PlacesOfOccurrence = TerrainType.Anywhere;
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;
        Alignment = Alignment.OrderLife;

        AttackValue = 133;
        DefenseValue = 205;
        InitiateValue = 73;
        AimValue = 55;

        AttacksPerRound = 2;

        HealthPoints = 35;
        PainTolerancePoints = 215;

        AstralMagicResistance = 190;
        MentalMagicResistance = 190;
        PoisonResistance = Int32.MaxValue;

        Psi = new PsiPyarron();
        PsiPoints = 70;
        ManaPoints = 153;

        Intelligence = Enums.Intelligence.Outstanding;
        ExperiencePoints = 28000;
    }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(9)]
    public override int GetDamage() => DiceThrow._2D6() + 9;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public Deity God => Deity.Domvik;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 90), new Speed(TravelMode.InTheAir, 150)];
}