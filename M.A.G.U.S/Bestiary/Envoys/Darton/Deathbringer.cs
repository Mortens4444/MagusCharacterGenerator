using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Things.Armors;

namespace M.A.G.U.S.Bestiary.Envoys.Darton;

public sealed class Deathbringer : Creature
{
    public Deathbringer()
    {
        Armor = new NaturalArmor(11);
        PlacesOfOccurrence = TerrainType.Anywhere;
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;
        Alignment = Alignment.Death;

        AttackValue = 145;
        DefenseValue = 190;
        InitiateValue = 85;
        AimValue = 75;

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
        ExperiencePoints = 45000;
    }

    [DiceThrow(ThrowType._3D6)]
    [DiceThrowModifier(10)]
    public override int GetDamage() => DiceThrow._3D6() + 10;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 120),
        new Speed(TravelMode.InTheAir, 150)
    ];
}