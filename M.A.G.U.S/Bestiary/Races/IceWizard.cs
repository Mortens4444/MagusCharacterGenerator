using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class IceWizard : Creature
{
    public IceWizard()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence =
            TerrainType.NorthernSnowfield |
            TerrainType.SouthernSnowfield |
            TerrainType.Icefield |
            TerrainType.Mountains |
            TerrainType.ArcticForest |
            TerrainType.InnerTerritory;

        AttackValue = 40;
        DefenseValue = 90;
        InitiateValue = 40;
        AimValue = 45;

        HealthPoints = 6;
        PainTolerancePoints = 15;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = 71;
        PoisonResistance = 5;

        ManaPoints = 50;

        Intelligence = Enums.Intelligence.Outstanding;
        Alignment = Alignment.Chaos;
        ExperiencePoints = 1150;
    }

    public override string Name => "Ice Wizard";

    public override int GetDamage() => 0;

    [DiceThrow(ThrowType._1D2)]
    public override int GetNumberAppearing() => DiceThrow._1D2();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 120)];
}