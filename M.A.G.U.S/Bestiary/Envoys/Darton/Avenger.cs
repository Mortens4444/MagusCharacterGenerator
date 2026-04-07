using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Things.Armors;

namespace M.A.G.U.S.Bestiary.Envoys.Darton;

public sealed class Avenger : Creature
{
    public Avenger()
    {
        Armor = new NaturalArmor(10);
        PlacesOfOccurrence = TerrainType.Anywhere;
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;
        Alignment = Alignment.Death;

        AttackValue = 130;
        DefenseValue = 174;
        InitiateValue = 67;
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
        ExperiencePoints = 25000;
    }

    [DiceThrow(ThrowType._3D6)]
    [DiceThrowModifier(7)]
    public override int GetDamage() => DiceThrow._3D6() + 7;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 120),
        new Speed(TravelMode.InTheAir, 150)
    ];
}
