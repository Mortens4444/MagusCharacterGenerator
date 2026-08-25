using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Places;

public static class TravelCalculator
{
    /// <summary>Roads wind through terrain instead of cutting the straight line CityCoordinates measures,
    /// so a traveler on foot, horseback or stagecoach actually covers roughly 30% more ground than the
    /// map distance suggests. Flying is left at the map distance - a direct, unobstructed path.</summary>
    private const double RoadDistanceMultiplier = 1.3;

    /// <summary>A ship can't cut across land, so it follows the coastline/sea lanes around whatever's in
    /// the way - for two points on this map that's typically a much bigger detour than a road ever needs,
    /// hence the much larger multiplier than RoadDistanceMultiplier.</summary>
    private const double SeaRouteDistanceMultiplier = 3;

    /// <summary>Cities further than this from a route's straight line don't count as "along the way" -
    /// wide enough to cover a plausible detour, narrow enough that most long trips don't sweep in half
    /// the map. Used by FindWaypointCities.</summary>
    private const double RouteCorridorMiles = 250;

    private static double GetDistanceMultiplier(TransportMode mode) => mode switch
    {
        TransportMode.Walking or TransportMode.Horseback or TransportMode.Stagecoach => RoadDistanceMultiplier,
        TransportMode.Ship => SeaRouteDistanceMultiplier,
        _ => 1.0
    };

    /// <summary>How many days a journey between two points takes at a given transport mode, for a specific traveler (Walking speed depends on race).</summary>
    public static double CalculateDays(WorldPosition from, WorldPosition to, TransportMode mode, Character traveler)
        => (from.DistanceTo(to) * GetDistanceMultiplier(mode)) / mode.GetDailyMiles(traveler);

    /// <summary>How many days a journey between two cities takes at a given transport mode, for a specific traveler (Walking speed depends on race).</summary>
    public static double CalculateDays(City from, City to, TransportMode mode, Character traveler)
        => CalculateDays(CityCoordinates.GetPosition(from), CityCoordinates.GetPosition(to), mode, traveler);

    /// <summary>Copper coins charged per mile of passage. No book figure exists for sea fares
    /// (same gap noted on TransportMode.Ship's DailyMiles), so this approximates a coastal
    /// passenger fare rather than the cost of owning a ship outright.</summary>
    private const decimal CopperPerMileByShip = 1;

    /// <summary>Passenger fare for hiring sea passage between two points, charged when a character travels by Ship instead of their own transport - scaled by SeaRouteDistanceMultiplier, same as the travel time, since the fare is meant to reflect the miles actually sailed.</summary>
    public static Money CalculateShipFare(WorldPosition from, WorldPosition to)
        => new(copper: (decimal)(from.DistanceTo(to) * SeaRouteDistanceMultiplier) * CopperPerMileByShip);

    /// <summary>Passenger fare for hiring sea passage between two cities, charged when a character travels by Ship instead of their own transport.</summary>
    public static Money CalculateShipFare(City from, City to)
        => CalculateShipFare(CityCoordinates.GetPosition(from), CityCoordinates.GetPosition(to));

    /// <summary>
    /// Cities (other than the two endpoints) that lie close enough to a journey's straight-line route to
    /// reasonably say the traveler passes near them - see Character.TravelWaypoints, which surfaces this
    /// to the player as flavor/notifications while a journey is in progress. Returned in the order
    /// they're reached, each paired with how far along the route (0 at the origin, 1 at the destination)
    /// it sits.
    /// </summary>
    public static IReadOnlyList<TravelWaypoint> FindWaypointCities(WorldPosition from, WorldPosition to)
    {
        var routeLength = from.DistanceTo(to);
        if (routeLength <= 0)
        {
            return [];
        }

        var waypoints = new List<TravelWaypoint>();
        foreach (var city in Enum.GetValues<City>())
        {
            if (city is City.Unknown || !CityCoordinates.TryGetPosition(city, out var point))
            {
                continue;
            }

            // Project the city onto the route line, clamped to the segment via the t<=0/t>=1 checks below.
            var t = (((point.X - from.X) * (to.X - from.X)) + ((point.Y - from.Y) * (to.Y - from.Y))) / (routeLength * routeLength);
            if (t is <= 0 or >= 1)
            {
                continue; // behind the origin or beyond the destination - not "along the way"
            }

            var closestPointOnRoute = new WorldPosition(from.X + (t * (to.X - from.X)), from.Y + (t * (to.Y - from.Y)));
            if (point.DistanceTo(closestPointOnRoute) <= RouteCorridorMiles)
            {
                waypoints.Add(new TravelWaypoint(city, t));
            }
        }

        return [.. waypoints.OrderBy(w => w.RouteFraction)];
    }
}

/// <summary>A city a journey's route passes near, and how far along the route (0 = origin, 1 = destination) it sits - see TravelCalculator.FindWaypointCities.</summary>
public readonly record struct TravelWaypoint(City City, double RouteFraction);
