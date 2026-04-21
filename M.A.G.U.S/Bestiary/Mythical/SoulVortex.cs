using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class SoulVortex : Creature
{
    public SoulVortex()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;
        PlacesOfOccurrence = TerrainType.CursedLand;

        InitiateValue = 50;
    }

    public override string Name => "Soul vortex";

    [DiceThrowModifier(0)]
    public override int GetDamage() => 0; // See description.

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 250)];
}
