using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Places;
using MAGUS.Races;

namespace MAGUS.Test;

[TestFixture]
public class CharacterPortalBehaviorTests
{
    private static Character CreateWizard(int manaPoints)
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Wizard());
        character.ManaPoints = manaPoints;
        return character;
    }

    private static Character CreateNonWizard(int manaPoints)
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Craftsman());
        character.ManaPoints = manaPoints;
        return character;
    }

    [Test]
    public void CanOpenWizardPortal_NonWizard_IsFalse()
    {
        var character = CreateNonWizard(1000);

        Assert.That(character.CanOpenWizardPortal, Is.False);
    }

    [Test]
    public void CanOpenWizardPortal_WizardWithInsufficientMana_IsFalse()
    {
        var character = CreateWizard(Character.WizardPortalManaCost - 1);

        Assert.That(character.CanOpenWizardPortal, Is.False);
    }

    [Test]
    public void CanOpenWizardPortal_WizardWithExactlyEnoughMana_IsTrue()
    {
        var character = CreateWizard(Character.WizardPortalManaCost);

        Assert.That(character.CanOpenWizardPortal, Is.True);
    }

    [Test]
    public void TryOpenWizardPortal_WhenIneligible_ReturnsFalseAndChangesNothing()
    {
        var character = CreateNonWizard(1000);
        var originalLocation = character.CurrentLocation;
        var originalMana = character.ManaPoints;

        var result = character.TryOpenWizardPortal(City.Ordan);

        Assert.That(result, Is.False);
        Assert.That(character.CurrentLocation, Is.EqualTo(originalLocation));
        Assert.That(character.ManaPoints, Is.EqualTo(originalMana));
    }

    [Test]
    public void TryOpenWizardPortal_WhenEligible_SpendsManaAndMovesInstantly()
    {
        var character = CreateWizard(Character.WizardPortalManaCost + 10);

        var result = character.TryOpenWizardPortal(City.Ordan);

        Assert.That(result, Is.True);
        Assert.That(character.ManaPoints, Is.EqualTo(10));
        Assert.That(character.CurrentLocation, Is.EqualTo(City.Ordan));
        Assert.That(character.Position, Is.EqualTo(CityCoordinates.GetPosition(City.Ordan)));
    }
}
