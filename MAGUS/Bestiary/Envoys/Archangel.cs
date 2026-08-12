using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Qualifications.Scientific.Psi;
using MAGUS.Things.Armors;

namespace MAGUS.Bestiary.Envoys;

public sealed class Archangel : Creature
{
    public Archangel()
    {
        Armor = new NaturalArmor(14);
        PlacesOfOccurrence = TerrainType.Anywhere;
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;
        Alignment = Alignment.OrderLife;

        AttackValue = 153;
        DefenseValue = 230;
        InitiateValue = 85;
        AimValue = 90;

        AttacksPerRound = 2;

        HealthPoints = 35;
        PainTolerancePoints = 270;

        AstralMagicResistance = 245;
        MentalMagicResistance = 245;
        PoisonResistance = Int32.MaxValue;

        Psi = new PsiPyarron();
        PsiPoints = 90;
        ManaPoints = 200;

        Intelligence = Enums.Intelligence.Outstanding;
        ExperiencePoints = 50000;
    }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(10)]
    public override int GetDamage() => DiceThrow._2D6() + 10;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public Deity God => Deity.Domvik;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 90), new Speed(TravelMode.InTheAir, 150)];
}