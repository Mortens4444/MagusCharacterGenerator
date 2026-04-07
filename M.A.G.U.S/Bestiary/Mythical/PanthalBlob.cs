using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class PanthalBlob : Creature
{
    public PanthalBlob()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.Catacombs | TerrainType.Underground | TerrainType.DeepUnderground | TerrainType.OldDilapidatedBuilding | TerrainType.InnerChamber | TerrainType.Cave;

        AttackValue = 80;
        DefenseValue = 80;
        InitiateValue = 10;
        AimValue = 6;

        HealthPoints = 36;
        PainTolerancePoints = 60;

        AstralMagicResistance = 10;
        MentalMagicResistance = 10;
        PoisonResistance = 12;

        Intelligence = Enums.Intelligence.Low;
        ExperiencePoints = 270;
    }

    public override string Name => "Panthal blob";

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override double AttacksPerRound => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 30)];
}