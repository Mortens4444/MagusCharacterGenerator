using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Places;
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
    public void CalculateDays_Horseback_MatchesDistanceOverDailyMiles()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Craftsman());
        var distance = CityCoordinates.DistanceInMiles(City.Pyarron, City.Toron);

        var days = TravelCalculator.CalculateDays(City.Pyarron, City.Toron, TransportMode.Horseback, character);

        Assert.That(days, Is.EqualTo(distance / 90).Within(0.0001));
    }

    [Test]
    public void CalculateDays_Walking_UsesRaceSpecificSpeed()
    {
        var human = new Character(new Settings(true), "Test", new Human(), new Craftsman());
        var elf = new Character(new Settings(true), "Test", new Elf(), new Craftsman());
        var dwarf = new Character(new Settings(true), "Test", new Dwarf(), new Craftsman());
        var distance = CityCoordinates.DistanceInMiles(City.Pyarron, City.Toron);

        Assert.That(TravelCalculator.CalculateDays(City.Pyarron, City.Toron, TransportMode.Walking, human), Is.EqualTo(distance / 45).Within(0.0001));
        Assert.That(TravelCalculator.CalculateDays(City.Pyarron, City.Toron, TransportMode.Walking, elf), Is.EqualTo(distance / 90).Within(0.0001));
        Assert.That(TravelCalculator.CalculateDays(City.Pyarron, City.Toron, TransportMode.Walking, dwarf), Is.EqualTo(distance / 30).Within(0.0001));
    }
}
