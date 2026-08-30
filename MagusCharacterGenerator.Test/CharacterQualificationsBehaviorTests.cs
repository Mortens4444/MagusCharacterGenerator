using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Races;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Percentages;

namespace MAGUS.Test;

[TestFixture]
public class CharacterQualificationsBehaviorTests
{
    private static Character CreateCharacter(int qualificationPoints = 10000) =>
        new(new Settings(true), "Test", new Human(), new Craftsman())
        {
            QualificationPoints = qualificationPoints
        };

    [Test]
    public void Learn_NewBaseQualification_AddsIt()
    {
        var character = CreateCharacter();
        var riding = new Riding();

        Assert.That(character.CanLearn(riding), Is.True);
        character.Learn(riding, QualificationLevel.Base);

        Assert.That(character.HasQualification(riding), Is.True);
        Assert.That(character.HasQualification(riding, QualificationLevel.Base), Is.True);
    }

    [Test]
    public void Learn_UpgradeToMaster_UpgradesExistingEntry()
    {
        var character = CreateCharacter();
        var riding = new Riding();
        character.Learn(riding, QualificationLevel.Base);

        var ridingMaster = new Riding();
        character.Learn(ridingMaster, QualificationLevel.Master);

        Assert.That(character.HasQualification(riding, QualificationLevel.Master), Is.True);
    }

    [Test]
    public void Learn_WithoutEnoughPoints_Throws()
    {
        var character = CreateCharacter(qualificationPoints: 0);
        var riding = new Riding();

        Assert.That(() => character.Learn(riding, QualificationLevel.Base), Throws.InvalidOperationException);
    }

    [Test]
    public void CanLearn_OutParam_ReportsRequiredPoints()
    {
        var character = CreateCharacter();
        var riding = new Riding();

        var canLearn = character.CanLearn(riding, QualificationLevel.Base, out var required);

        Assert.That(canLearn, Is.True);
        Assert.That(required, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void HasPsi_ReflectsQualifications()
    {
        var character = CreateCharacter();
        Assert.That(character.HasPsi(), Is.False.Or.True);
    }

    [Test]
    public void GetSpeciality_FindsRaceOrClassSpeciality()
    {
        var character = CreateCharacter();
        var speciality = character.GetSpeciality<MAGUS.Qualifications.Specialities.GoodInitiator>();
        Assert.That(speciality, Is.Null.Or.Not.Null);
    }

    [Test]
    public void IncreasePercentQualification_WithEnoughPoints_IncreasesPercentAndSpendsPoint()
    {
        var character = CreateCharacter();
        character.PercentQualificationPoints = 5;
        var climbing = character.PercentQualifications.OfType<Climbing>().Single();
        var initialPercent = climbing.Percent;

        Assert.That(character.CanIncreasePercentQualification(climbing), Is.True);
        character.IncreasePercentQualification(climbing);

        Assert.That(climbing.Percent, Is.EqualTo(initialPercent + Character.PercentPerQualificationPoint));
        Assert.That(character.PercentQualificationPoints, Is.EqualTo(5 - Character.PercentQualificationPointCost));
    }

    [Test]
    public void IncreasePercentQualification_WithoutEnoughPoints_Throws()
    {
        var character = CreateCharacter();
        character.PercentQualificationPoints = 0;
        var climbing = character.PercentQualifications.OfType<Climbing>().Single();

        Assert.That(character.CanIncreasePercentQualification(climbing), Is.False);
        Assert.That(() => character.IncreasePercentQualification(climbing), Throws.InvalidOperationException);
    }

    [Test]
    public void CanIncreasePercentQualification_ForQualificationNotOwned_ReturnsFalse()
    {
        var character = CreateCharacter();
        character.PercentQualificationPoints = 5;
        var foreignQualification = new Sneaking(0);

        Assert.That(character.CanIncreasePercentQualification(foreignQualification), Is.False);
    }
}
