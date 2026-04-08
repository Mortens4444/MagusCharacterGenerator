using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Kurun : Creature
{
    public Kurun()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.Cave | TerrainType.Mines;

        AttackValue = 55;
        DefenseValue = 96;
        InitiateValue = 25;

        HealthPoints = 17;
        PainTolerancePoints = 75;

        AstralMagicResistance = 18;
        MentalMagicResistance = 18;
        PoisonResistance = 7;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.Order;
        ExperiencePoints = 185;

        // Several properties may be special depending on the specific kurun:
        // AttackValue, DefenseValue, InitiateValue, AimValue, AttacksPerRound,
        // AstralMagicResistance, MentalMagicResistance, Psi, Intelligence,
        // Alignment, ManaPoints, ExperiencePoints.
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 120)];
}
