using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Places;
using MAGUS.Races;

namespace MAGUS.Test;

[TestFixture]
public class CharacterGroupBehaviorTests
{
    private static Character CreateCharacter(City birthplace) =>
        new(new Settings(true), "Test", new Human(), new Craftsman())
        {
            Birthplace = birthplace
        };

    [Test]
    public void IsAtSameLocationAs_BothStationaryInSameCity_ReturnsTrue()
    {
        var a = CreateCharacter(City.Pyarron);
        var b = CreateCharacter(City.Pyarron);

        Assert.That(a.IsAtSameLocationAs(b), Is.True);
    }

    [Test]
    public void IsAtSameLocationAs_DifferentCities_ReturnsFalse()
    {
        var a = CreateCharacter(City.Pyarron);
        var b = CreateCharacter(City.Toron);

        Assert.That(a.IsAtSameLocationAs(b), Is.False);
    }

    [Test]
    public void IsAtSameLocationAs_OtherIsTraveling_ReturnsFalse()
    {
        var a = CreateCharacter(City.Pyarron);
        var b = CreateCharacter(City.Pyarron);
        b.TravelDestination = City.Toron;
        b.TravelDepartureUtc = DateTime.UtcNow;
        b.TravelDurationDays = 1;

        Assert.That(a.IsAtSameLocationAs(b), Is.False);
    }

    [Test]
    public void IsAtSameLocationAs_UnknownCity_ReturnsFalse()
    {
        var a = CreateCharacter(City.Unknown);
        var b = CreateCharacter(City.Unknown);

        Assert.That(a.IsAtSameLocationAs(b), Is.False);
    }

    [Test]
    public void IsInGroup_ReflectsGroupMemberNames()
    {
        var character = CreateCharacter(City.Pyarron);
        Assert.That(character.IsInGroup, Is.False);

        character.GroupMemberNames.Add("Ally");

        Assert.That(character.IsInGroup, Is.True);
    }
}
