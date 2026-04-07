using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Armors;

namespace M.A.G.U.S.Bestiary.Envoys.Ranagol;

public sealed class Damquuis : Creature
{
    public Damquuis()
    {
        Armor = new NaturalArmor(10);
        PlacesOfOccurrence = TerrainType.Anywhere;
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;
        Alignment = Alignment.Death;

        AttackValue = 130;
        DefenseValue = 190;
        InitiateValue = 70;

        AttacksPerRound = 2;

        HealthPoints = 35;
        PainTolerancePoints = 215;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Outstanding;
        ExperiencePoints = 20000;
    }

    public override string[] Images => ["ranagol.png"];

    [DiceThrow(ThrowType._3D6)]
    [DiceThrowModifier(7)]
    public override int GetDamage() => DiceThrow._3D6() + 7;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 90),
        new Speed(TravelMode.InTheAir, 150)
    ];
}