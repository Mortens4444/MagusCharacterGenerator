namespace MAGUS.GameSystem.Places;

public static class TravelCalculator
{
    /// <summary>How many days a journey between two cities takes at a given transport mode, for a specific traveler (Walking speed depends on race).</summary>
    public static double CalculateDays(City from, City to, TransportMode mode, Character traveler)
        => CityCoordinates.DistanceInMiles(from, to) / mode.GetDailyMiles(traveler);
}
