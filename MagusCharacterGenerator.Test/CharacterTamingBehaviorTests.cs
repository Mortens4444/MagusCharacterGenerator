using MAGUS.Bestiary.Animals;
using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications.Laical;
using MAGUS.Races;

namespace MAGUS.Test;

[TestFixture]
public class CharacterTamingBehaviorTests
{
    private static Character CreateCharacter() =>
        new(new Settings(true), "Test", new Human(), new Craftsman());

    private static Character CreateMasterAnimalTrainer()
    {
        var character = CreateCharacter();
        character.Qualifications.Add(new AnimalTraining(QualificationLevel.Master));
        return character;
    }

    [Test]
    public void HasMasterAnimalTraining_WithoutQualification_IsFalse()
    {
        var character = CreateCharacter();

        Assert.That(character.HasMasterAnimalTraining, Is.False);
    }

    [Test]
    public void HasMasterAnimalTraining_WithBaseQualificationOnly_IsFalse()
    {
        var character = CreateCharacter();
        character.Qualifications.Add(new AnimalTraining(QualificationLevel.Base));

        Assert.That(character.HasMasterAnimalTraining, Is.False);
    }

    [Test]
    public void HasMasterAnimalTraining_WithMasterQualification_IsTrue()
    {
        var character = CreateMasterAnimalTrainer();

        Assert.That(character.HasMasterAnimalTraining, Is.True);
    }

    [Test]
    public void CanTame_NullCreature_IsFalse()
    {
        var character = CreateMasterAnimalTrainer();

        Assert.That(character.CanTame(null), Is.False);
    }

    [Test]
    public void CanTame_WithoutMasterQualification_IsFalse()
    {
        var character = CreateCharacter();

        Assert.That(character.CanTame(new CommonHorse()), Is.False);
    }

    [Test]
    public void CanTame_NonAnimalIntelligenceCreature_IsFalse()
    {
        // Gliad has TravelMode.OnLand but Intelligence.High, not Intelligence.Animal.
        var character = CreateMasterAnimalTrainer();

        Assert.That(character.CanTame(new Gliad()), Is.False);
    }

    [Test]
    public void CanTame_ExclusivelyAquaticAnimal_IsFalse()
    {
        // Barracuda is Intelligence.Animal but its only Speed is TravelMode.InWater.
        var character = CreateMasterAnimalTrainer();

        Assert.That(character.CanTame(new Barracuda()), Is.False);
    }

    [Test]
    public void CanTame_LandAnimalWithMasterQualification_IsTrue()
    {
        var character = CreateMasterAnimalTrainer();

        Assert.That(character.CanTame(new CommonHorse()), Is.True);
    }

    [Test]
    public void TryTameCreature_WhenCanTameIsFalse_ReturnsFalseWithoutAddingOrRolling()
    {
        var character = CreateCharacter();
        var horse = new CommonHorse();

        var result = character.TryTameCreature(horse);

        Assert.That(result, Is.False);
        Assert.That(character.TamedCreatures, Is.Empty);
    }

    [Test]
    public void TryTameCreature_WhenEligible_CoversBothSuccessAndFailureAcrossManyRolls()
    {
        var character = CreateMasterAnimalTrainer();
        character.CurrentLocation = City.Ordan;

        var sawSuccess = false;
        var sawFailure = false;

        for (var i = 0; i < 200 && !(sawSuccess && sawFailure); i++)
        {
            var horse = new CommonHorse();
            var before = character.TamedCreatures.Count;

            var result = character.TryTameCreature(horse);

            if (result)
            {
                sawSuccess = true;
                Assert.That(character.TamedCreatures.Count, Is.EqualTo(before + 1));
                var added = character.TamedCreatures[^1];
                Assert.That(added.Creature, Is.SameAs(horse));
                Assert.That(added.Location, Is.EqualTo(City.Ordan));
            }
            else
            {
                sawFailure = true;
                Assert.That(character.TamedCreatures.Count, Is.EqualTo(before));
            }
        }

        Assert.That(sawSuccess, Is.True, "Expected at least one successful taming roll across 200 attempts.");
        Assert.That(sawFailure, Is.True, "Expected at least one failed taming roll across 200 attempts.");
    }
}
