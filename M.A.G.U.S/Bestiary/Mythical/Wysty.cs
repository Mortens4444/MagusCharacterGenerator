using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class Wysty : Creature
{
    public Wysty()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Icefield;

        AttackValue = 90;
        DefenseValue = 150;
        InitiateValue = 90;
        AimValue = 20;

        HealthPoints = 15;
        PainTolerancePoints = 28;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        ManaPoints = 60;

        Intelligence = Enums.Intelligence.Outstanding;
        Alignment = Alignment.Chaos;
        ExperiencePoints = 880;
    }

    public override double AttacksPerRound => 3;

    [DiceThrowModifier(0)]
    public override int GetDamage() => 0;

    [DiceThrow(ThrowType._1D3)]
    public override int GetNumberAppearing() => DiceThrow._1D3();

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 150)];
}