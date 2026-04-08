using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class SwampMist : Creature
{
    public SwampMist()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Big;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 80;
        DefenseValue = 20;
        InitiateValue = 0;

        AttacksPerRound = 10;

        HealthPoints = 40;
        PainTolerancePoints = 80;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.None;
        ExperiencePoints = 550;
    }

    [DiceThrow(ThrowType._2D10)]
    public override int GetDamage() => DiceThrow._2D10();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override string Name => "Swamp mist";

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 10)];
}