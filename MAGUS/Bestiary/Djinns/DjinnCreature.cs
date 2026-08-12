using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;

namespace MAGUS.Bestiary.Djinns;

public abstract class DjinnCreature : Creature
{
    protected DjinnCreature()
    {
        Occurrence = Occurrence.VeryRare;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;
    }

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;
}
