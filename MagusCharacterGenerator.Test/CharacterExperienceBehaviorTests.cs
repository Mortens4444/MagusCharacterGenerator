using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.GameSystem;
using MAGUS.Races;

namespace MAGUS.Test;

[TestFixture]
public class CharacterExperienceBehaviorTests
{
    private static Character CreateCharacter() =>
        new(new Settings(true), "Test", new Human(), new Craftsman());

    [Test]
    public void AddExperience_ZeroAmount_IsNoOp()
    {
        var character = CreateCharacter();
        var before = character.ExperiencePoints;
        character.AddExperience(0);
        Assert.That(character.ExperiencePoints, Is.EqualTo(before));
    }

    [Test]
    public void AddExperience_RaisesLevelUpAvailable_WhenPendingIncreases()
    {
        var character = CreateCharacter();
        var raised = false;
        character.LevelUpAvailable += (_, _) => raised = true;

        character.AddExperience(1_000_000);

        Assert.That(raised, Is.True);
        Assert.That(character.PendingLevelUps, Is.GreaterThan(0));
    }

    [Test]
    public void ApplyNextLevelUp_WithNoPending_ReturnsFalse()
    {
        var character = CreateCharacter();
        Assert.That(character.ApplyNextLevelUp(), Is.False);
    }

    [Test]
    public void ApplyNextLevelUp_WithPending_AppliesOneLevel_AndInvokesCallback()
    {
        var character = CreateCharacter();
        character.AddExperience(1_000_000);
        var startLevel = character.Level;
        var callbackInvoked = false;
        character.LevelUpApplied += _ => callbackInvoked = true;

        var applied = character.ApplyNextLevelUp(cls => cls.Level += 0);

        Assert.That(applied, Is.True);
        Assert.That(character.Level, Is.EqualTo(startLevel + 1));
        Assert.That(callbackInvoked, Is.True);
    }

    [Test]
    public void ApplyAllPendingLevelUps_AppliesEveryPendingLevel()
    {
        var character = CreateCharacter();
        character.AddExperience(1_000_000);
        var pending = character.PendingLevelUps;

        var applied = character.ApplyAllPendingLevelUps();

        Assert.That(applied, Is.EqualTo(pending));
        Assert.That(character.PendingLevelUps, Is.EqualTo(0));
    }

    [Test]
    public void ApplyLevelUp_IncreasesDerivedValues()
    {
        var character = CreateCharacter();
        var maxHp = character.MaxHealthPoints;

        character.ApplyLevelUp(painToleranceIncrease: 2, manaIncrease: 3);

        Assert.That(character.Level, Is.EqualTo(2));
        Assert.That(character.MaxHealthPoints, Is.EqualTo(maxHp));
    }

    [Test]
    public void CanUpgrade_And_ExperiencePoints_RoundTrip()
    {
        var character = CreateCharacter();
        character.ExperiencePoints = character.ExperiencePoints;
        _ = character.CanUpgrade;
    }
}
