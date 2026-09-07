using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.GameSystem;
using MAGUS.Races;
using MAGUS.Things.Weapons.CrushingWeapons;

namespace MAGUS.Test;

[TestFixture]
public class CharacterTwoHandedWeaponTests
{
    private static Character CreateCharacter(MAGUS.Races.IRace? race = null) =>
        new(new Settings(true), "Test", race ?? new Human(), new Craftsman());

    [Test]
    public void PrimaryWeapon_TwoHanded_MirrorsIntoSecondaryWeapon()
    {
        var character = CreateCharacter();
        var mace = new TwoHandedMace(); // AttacksPerRound 0.5 -> IsTwoHanded
        character.Equipment.Add(mace);

        character.PrimaryWeapon = mace;

        Assert.That(character.SecondaryWeapon, Is.SameAs(mace));
    }

    [Test]
    public void SecondaryWeapon_TwoHanded_MirrorsIntoPrimaryWeapon()
    {
        var character = CreateCharacter();
        var mace = new TwoHandedMace();
        character.Equipment.Add(mace);

        character.SecondaryWeapon = mace;

        Assert.That(character.PrimaryWeapon, Is.SameAs(mace));
    }

    [Test]
    public void PrimaryWeapon_TwoHanded_DoesNotMirror_ForGiant()
    {
        var character = CreateCharacter(new ForestGiant());
        var mace = new TwoHandedMace();
        character.Equipment.Add(mace);

        character.PrimaryWeapon = mace;

        Assert.That(character.SecondaryWeapon, Is.Null);
    }

    [Test]
    public void AttackModes_WithMirroredTwoHandedWeapon_ListsItOnlyOnce()
    {
        var character = CreateCharacter();
        var mace = new TwoHandedMace();
        character.Equipment.Add(mace);
        character.PrimaryWeapon = mace;

        var meleeAttacksWithMace = character.AttackModes.Count(a => a is MeleeAttack melee && melee.Weapon == mace);

        Assert.That(meleeAttacksWithMace, Is.EqualTo(1));
    }

    [Test]
    public void OneHandedWeapon_DoesNotMirror()
    {
        var character = CreateCharacter();
        var staff = new ShortStaff(); // AttacksPerRound 1 -> not two-handed
        character.Equipment.Add(staff);

        character.PrimaryWeapon = staff;

        Assert.That(character.SecondaryWeapon, Is.Null);
    }
}
