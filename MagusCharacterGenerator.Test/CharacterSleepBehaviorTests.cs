using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.GameSystem;
using MAGUS.Races;

namespace MAGUS.Test;

[TestFixture]
public class CharacterSleepBehaviorTests
{
    private static Character CreateCharacter() =>
        new(new Settings(true), "Test", new Human(), new Craftsman());

    [Test]
    public void ElapsedSleepHours_WhenNotSleeping_IsZero()
    {
        var character = CreateCharacter();
        Assert.That(character.ElapsedSleepHours, Is.EqualTo(0));
    }

    [Test]
    public void ElapsedSleepHours_PartWayThroughSleep_ReflectsRealElapsedTime()
    {
        var character = CreateCharacter();
        character.SleepDurationHours = 8;
        character.SleepStartUtc = DateTime.UtcNow.AddHours(-2);

        Assert.That(character.ElapsedSleepHours, Is.EqualTo(2).Within(0.01));
    }

    [Test]
    public void ElapsedSleepHours_IsCappedAtSleepDurationHours()
    {
        var character = CreateCharacter();
        character.SleepDurationHours = 8;
        character.SleepStartUtc = DateTime.UtcNow.AddHours(-20);

        Assert.That(character.ElapsedSleepHours, Is.EqualTo(8));
    }
}
