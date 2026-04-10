using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Armors;

namespace M.A.G.U.S.Bestiary.Envoys;

public sealed class Raquan : Creature
{
    public Raquan()
    {
        Armor = new NaturalArmor(9);
        PlacesOfOccurrence = TerrainType.Anywhere;
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;
        Alignment = Alignment.Death;

        AttackValue = 100;
        DefenseValue = 150;
        InitiateValue = 50;

        AttacksPerRound = 2;

        HealthPoints = 30;
        PainTolerancePoints = 160;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Outstanding;
        ExperiencePoints = 10000;
    }

    public override string[] Images => ["ranagol.png"];

    [DiceThrow(ThrowType._3D6)]
    [DiceThrowModifier(6)]
    public override int GetDamage() => DiceThrow._3D6() + 6;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public Deity God => Deity.Ranagol;

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 90),
        new Speed(TravelMode.InTheAir, 150)
    ];
}