using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Armors;

namespace M.A.G.U.S.Bestiary.Envoys.Ranagol;

public sealed class Arhquuis : Creature
{
    public Arhquuis()
    {
        Armor = new NaturalArmor(11);
        PlacesOfOccurrence = TerrainType.Anywhere;
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;
        Alignment = Alignment.Death;

        AttackValue = 150;
        DefenseValue = 220;
        InitiateValue = 80;

        AttacksPerRound = 2;

        HealthPoints = 35;
        PainTolerancePoints = 270;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Outstanding;
        ExperiencePoints = 40000;
    }

    public override string[] Images =>  ["ranagol.png"];

    [DiceThrow(ThrowType._3D6)]
    [DiceThrowModifier(8)]
    public override int GetDamage() => DiceThrow._3D6() + 8;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 90),
        new Speed(TravelMode.InTheAir, 150)
    ];
}