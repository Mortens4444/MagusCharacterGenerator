using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;

namespace M.A.G.U.S.Bestiary.Elementals;

public abstract class Elemental : Creature
{
    protected Elemental()
    {
        Occurrence = Occurrence.VeryRare;
        PlacesOfOccurrence = TerrainType.Anywhere;
        Alignment = Alignment.Neutral;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        AttacksPerRound = 2;

        MinIntelligence = Enums.Intelligence.None;
        MaxIntelligence = Enums.Intelligence.Low;
    }

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;
}
