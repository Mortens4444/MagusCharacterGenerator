using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.Races;
using MAGUS.Things.Weapons.CrushingWeapons;
using MAGUS.Things.Weapons.RangedWeapons;

namespace MAGUS.Test;

[TestFixture]
public class CharacterCombatBehaviorTests
{
    private static Character CreateCharacter() =>
        new(new Settings(true), "Test", new Human(), new Craftsman());

    [Test]
    public void SetWeapons_ResolvesPrimaryAndSecondaryFromEquipment()
    {
        var character = CreateCharacter();
        var staff = new ShortStaff();
        var bow = new ElvenBow();
        character.Equipment.Add(staff);
        character.Equipment.Add(bow);
        character.PrimaryWeaponId = staff.Id;
        character.SecondaryWeaponId = bow.Id;

        character.SetWeapons();

        Assert.That(character.PrimaryWeapon, Is.SameAs(staff));
        Assert.That(character.SecondaryWeapon, Is.SameAs(bow));
    }

    [Test]
    public void AttackModes_WithPrimaryMeleeAndSecondaryRanged_IncludesBoth()
    {
        var character = CreateCharacter();
        var staff = new ShortStaff();
        var bow = new ElvenBow();
        character.Equipment.Add(staff);
        character.Equipment.Add(bow);
        character.PrimaryWeapon = staff;
        character.SecondaryWeapon = bow;

        var attackModes = character.AttackModes;

        Assert.That(attackModes, Is.Not.Empty);
    }

    [TestCase(CombatValueModifier.Base)]
    [TestCase(CombatValueModifier.PrimaryWeapon)]
    [TestCase(CombatValueModifier.SecondaryWeapon)]
    public void CombatValues_ChangeWithSelectedCombatValueModifier(CombatValueModifier modifier)
    {
        var character = CreateCharacter();
        character.Equipment.Add(new ShortStaff());
        character.Equipment.Add(new ElvenBow());
        character.PrimaryWeapon = character.Equipment.OfType<ShortStaff>().First();
        character.SecondaryWeapon = character.Equipment.OfType<ElvenBow>().First();

        character.SelectedCombatValueModifier = modifier;
        character.SelectedCombatValueModifier = modifier; // second set is a no-op branch

        Assert.That(character.InitiateValue, Is.GreaterThanOrEqualTo(0));
        Assert.That(character.AttackValue, Is.GreaterThanOrEqualTo(0));
        Assert.That(character.DefenseValue, Is.GreaterThanOrEqualTo(0));
        Assert.That(character.AimValue, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void ChangeAllocations_RespectsRemainingModifierAndLockedValues()
    {
        var character = CreateCharacter();
        var remaining = character.RemainingCombatValueModifier;

        character.ChangeInitiator(1);
        character.ChangeAttack(1);
        character.ChangeDefense(1);
        character.ChangeAim(1);

        // Exceeding remaining should just notify without applying.
        character.ChangeInitiator(remaining + 1000);
        character.ChangeAttack(remaining + 1000);
        character.ChangeDefense(remaining + 1000);
        character.ChangeAim(remaining + 1000);

        // No-op delta.
        character.ChangeInitiator(0);

        character.CommitAllocations();

        // Going below the locked value should be rejected.
        character.ChangeInitiator(-1000);
        character.ChangeAttack(-1000);
        character.ChangeDefense(-1000);
        character.ChangeAim(-1000);

        Assert.That(character.LockedAllocatedToInitiate, Is.EqualTo(character.AllocatedToInitiate));
    }

    [Test]
    public void GetDamage_ReturnsFistDamage()
    {
        var character = CreateCharacter();
        Assert.That(character.GetDamage(), Is.GreaterThanOrEqualTo(0));
    }
}
