using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.GameSystem;
using MAGUS.Races;
using MAGUS.Things.Weapons.StabbingWeapons;
using MAGUS.Utils;
using Newtonsoft.Json;

namespace MAGUS.Test;

[TestFixture]
public class CharacterWeaponEquipmentTests
{
    private static JsonSerializerSettings Settings() => new()
    {
        TypeNameHandling = TypeNameHandling.Auto,
        SerializationBinder = new LegacyAssemblySerializationBinder(),
        PreserveReferencesHandling = PreserveReferencesHandling.Objects
    };

    [Test]
    public void Character_WithPrimaryWeaponEquippedAndInEquipment_RoundTripsWeaponAfterSerialization()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Craftsman());
        var weapon = new Dagger();
        character.Equipment.Add(weapon);
        character.PrimaryWeapon = weapon;

        var json = JsonConvert.SerializeObject(character, Settings());
        var reloaded = JsonConvert.DeserializeObject<Character>(json, Settings());
        reloaded!.SetWeapons();

        Assert.That(reloaded.PrimaryWeapon, Is.Not.Null, "Primary weapon was lost during round-trip.");
        Assert.That(reloaded.PrimaryWeapon, Is.InstanceOf<Dagger>());
    }

    [Test]
    public void RemoveEquipment_ClearsPrimaryWeapon_WhenRemovedItemWasEquippedAsPrimary()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Craftsman());
        var weapon = new Dagger();
        character.Equipment.Add(weapon);
        character.PrimaryWeapon = weapon;

        character.RemoveEquipment(weapon);

        Assert.That(character.PrimaryWeapon, Is.Null, "PrimaryWeapon still points at a discarded item.");
        Assert.That(character.PrimaryWeaponId, Is.Null, "PrimaryWeaponId still points at a discarded item's id.");
    }

    [Test]
    public void RemoveEquipment_ClearsSecondaryWeapon_WhenRemovedItemWasEquippedAsSecondary()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Craftsman());
        var weapon = new Dagger();
        character.Equipment.Add(weapon);
        character.SecondaryWeapon = weapon;

        character.RemoveEquipment(weapon);

        Assert.That(character.SecondaryWeapon, Is.Null, "SecondaryWeapon still points at a discarded item.");
        Assert.That(character.SecondaryWeaponId, Is.Null, "SecondaryWeaponId still points at a discarded item's id.");
    }

    [Test]
    public void Sell_ClearsPrimaryWeapon_WhenSoldItemWasEquippedAsPrimary()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Craftsman());
        var weapon = new Dagger();
        character.Equipment.Add(weapon);
        character.PrimaryWeapon = weapon;

        character.Sell(weapon);

        Assert.That(character.PrimaryWeapon, Is.Null, "PrimaryWeapon still points at a sold item.");
        Assert.That(character.PrimaryWeaponId, Is.Null, "PrimaryWeaponId still points at a sold item's id.");
    }

    [Test]
    public void RemoveEquipment_ThenSerializeAndReload_DoesNotResurrectStaleWeaponId()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Craftsman());
        var weapon = new Dagger();
        character.Equipment.Add(weapon);
        character.PrimaryWeapon = weapon;
        character.RemoveEquipment(weapon);

        var json = JsonConvert.SerializeObject(character, Settings());
        var reloaded = JsonConvert.DeserializeObject<Character>(json, Settings());
        reloaded!.SetWeapons();

        Assert.That(reloaded.PrimaryWeaponId, Is.Null);
        Assert.That(reloaded.PrimaryWeapon, Is.Null);
    }
}
