using MAGUS.GameSystem.Attributes;
using MAGUS.Races;

namespace MAGUS.GameSystem.Places;

public static class TransportModeExtensions
{
    private const double DefaultWalkingDailyMiles = 45; // Ember (Human), p.352 - fallback for any race the book doesn't cover
    private const double DwarfWalkingDailyMiles = 30; // Törpe (Dwarf), p.352 - book: goblins use this too
    private const double ElfWalkingDailyMiles = 90; // Elf, p.352 - book: court orcs use this too

    /// <summary>
    /// Daily travel distance in miles for the given mode. Every mode but Walking is a fixed figure
    /// (see the [DailyMiles] attribute on each TransportMode value); Walking depends on the
    /// traveler's race per Első Törvénykönyv p.352 (Human 45, Dwarf 30, Elf 90, with half-elf/goblin/
    /// court orc using the Human/Dwarf/Elf figure respectively - anything else not covered by the
    /// book defaults to the Human figure).
    /// </summary>
    public static double GetDailyMiles(this TransportMode mode, Character traveler)
    {
        if (mode == TransportMode.Walking)
        {
            return traveler.Race switch
            {
                Dwarf or Goblin or CourtGoblin => DwarfWalkingDailyMiles,
                Elf or CourtOrc => ElfWalkingDailyMiles,
                _ => DefaultWalkingDailyMiles
            };
        }

        var field = typeof(TransportMode).GetField(mode.ToString());
        var attribute = (DailyMilesAttribute?)Attribute.GetCustomAttribute(field!, typeof(DailyMilesAttribute));
        return attribute?.DailyMiles ?? DefaultWalkingDailyMiles;
    }
}
