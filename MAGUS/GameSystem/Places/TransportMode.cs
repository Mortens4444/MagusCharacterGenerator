using MAGUS.GameSystem.Attributes;

namespace MAGUS.GameSystem.Places;

/// <summary>
/// Ways a character can travel between cities. Named TransportMode (not TravelMode) to avoid
/// colliding with MAGUS.Enums.TravelMode, an unrelated Bestiary concept (a creature's locomotion
/// medium - land/air/water/walls/underground). Speeds are daily-mile figures from Első Törvénykönyv
/// p.352 ("SEBESSÉG") where the book defines them (Walking, Horseback, Stagecoach); Ship and Flying
/// have no book source at all and use documented estimates instead - see the DailyMilesAttribute on
/// each.
/// </summary>
public enum TransportMode
{
    /// <summary>Race-dependent, not a fixed value - see TransportModeExtensions.GetDailyMiles.</summary>
    Walking,

    [DailyMiles(90)] // Utazó ló (travel horse), p.352
    Horseback,

    [DailyMiles(80)] // Postakocsi (stagecoach), p.352
    Stagecoach,

    [DailyMiles(60)] // No book figure exists for sea travel; estimated at a coastal trade ship's pace
    Ship,

    [DailyMiles(180)] // No book figure exists for flight; estimated as a rare magical/mount-borne pace
    Flying
}
