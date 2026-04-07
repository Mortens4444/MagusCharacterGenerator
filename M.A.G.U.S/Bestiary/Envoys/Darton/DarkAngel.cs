using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Things.Armors;

namespace M.A.G.U.S.Bestiary.Envoys.Darton;

public sealed class DarkAngel : Creature
{
    public DarkAngel()
    {
        Armor = new NaturalArmor(9);
        PlacesOfOccurrence = TerrainType.Anywhere;
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;
        Alignment = Alignment.Death;

        AttackValue = 111;
        DefenseValue = 154;
        InitiateValue = 50;

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
        ExperiencePoints = 12000;
    }

    public override string Name => "Dark angel";

    [DiceThrow(ThrowType._3D6)]
    [DiceThrowModifier(6)]
    public override int GetDamage() => DiceThrow._3D6() + 6;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 120),
        new Speed(TravelMode.InTheAir, 150)
    ];
}