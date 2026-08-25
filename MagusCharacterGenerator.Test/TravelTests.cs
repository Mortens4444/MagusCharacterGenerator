using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;
using MAGUS.Races;

namespace MAGUS.Test;

[TestFixture]
public class TravelTests
{
    [Test]
    public void DistanceInMiles_SameCity_IsZero()
    {
        Assert.That(CityCoordinates.DistanceInMiles(City.Pyarron, City.Pyarron), Is.EqualTo(0));
    }

    [Test]
    public void DistanceInMiles_IsSymmetric()
    {
        var forward = CityCoordinates.DistanceInMiles(City.Pyarron, City.Toron);
        var backward = CityCoordinates.DistanceInMiles(City.Toron, City.Pyarron);

        Assert.That(forward, Is.EqualTo(backward));
    }

    [Test]
    public void CalculateDays_Horseback_MatchesRoadDistanceOverDailyMiles()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Craftsman());
        var distance = CityCoordinates.DistanceInMiles(City.Pyarron, City.Toron);

        var days = TravelCalculator.CalculateDays(City.Pyarron, City.Toron, TransportMode.Horseback, character);

        // Horseback (like Walking) covers roads, not the straight-line map distance - see the
        // RoadDistanceMultiplier remarks on TravelCalculator.
        Assert.That(days, Is.EqualTo(distance * 1.3 / 90).Within(0.0001));
    }

    [Test]
    public void CalculateDays_Walking_UsesRaceSpecificSpeed()
    {
        var human = new Character(new Settings(true), "Test", new Human(), new Craftsman());
        var elf = new Character(new Settings(true), "Test", new Elf(), new Craftsman());
        var dwarf = new Character(new Settings(true), "Test", new Dwarf(), new Craftsman());
        var distance = CityCoordinates.DistanceInMiles(City.Pyarron, City.Toron) * 1.3;

        Assert.That(TravelCalculator.CalculateDays(City.Pyarron, City.Toron, TransportMode.Walking, human), Is.EqualTo(distance / 45).Within(0.0001));
        Assert.That(TravelCalculator.CalculateDays(City.Pyarron, City.Toron, TransportMode.Walking, elf), Is.EqualTo(distance / 90).Within(0.0001));
        Assert.That(TravelCalculator.CalculateDays(City.Pyarron, City.Toron, TransportMode.Walking, dwarf), Is.EqualTo(distance / 30).Within(0.0001));
    }

    [Test]
    public void CalculateDays_Ship_UsesSeaRouteDistance()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Craftsman());
        var distance = CityCoordinates.DistanceInMiles(City.Pyarron, City.Toron) * 3;

        var days = TravelCalculator.CalculateDays(City.Pyarron, City.Toron, TransportMode.Ship, character);

        // A ship can't cut across land, so it covers a much bigger detour than a road ever needs - see
        // the SeaRouteDistanceMultiplier remarks on TravelCalculator.
        Assert.That(days, Is.EqualTo(distance / 60).Within(0.0001));
    }

    [Test]
    public void CalculateDays_Flying_UsesStraightLineDistance()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Craftsman());
        var distance = CityCoordinates.DistanceInMiles(City.Pyarron, City.Toron);

        var days = TravelCalculator.CalculateDays(City.Pyarron, City.Toron, TransportMode.Flying, character);

        Assert.That(days, Is.EqualTo(distance / 180).Within(0.0001));
    }

    [Test]
    public void CalculateShipFare_UsesSeaRouteDistance()
    {
        var distance = CityCoordinates.DistanceInMiles(City.Pyarron, City.Toron) * 3;

        var fare = TravelCalculator.CalculateShipFare(City.Pyarron, City.Toron);

        Assert.That(fare, Is.EqualTo(new Money(copper: (decimal)distance)));
    }

    [Test]
    public void FindWaypointCities_ExcludesEndpoints()
    {
        var from = CityCoordinates.GetPosition(City.Pyarron);
        var to = CityCoordinates.GetPosition(City.Toron);

        var waypoints = TravelCalculator.FindWaypointCities(from, to);

        Assert.That(waypoints.Select(w => w.City), Does.Not.Contain(City.Pyarron));
        Assert.That(waypoints.Select(w => w.City), Does.Not.Contain(City.Toron));
    }
}
