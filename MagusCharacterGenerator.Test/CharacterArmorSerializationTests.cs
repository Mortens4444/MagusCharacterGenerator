using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.GameSystem;
using MAGUS.Races;
using MAGUS.Things.Armors;
using MAGUS.Utils;
using Newtonsoft.Json;

namespace MAGUS.Test;

[TestFixture]
public class CharacterArmorSerializationTests
{
    [Test]
    public void Character_WithArmorEquippedAndInEquipment_RoundTripsArmorAfterSerialization()
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            SerializationBinder = new LegacyAssemblySerializationBinder(),
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        };

        var character = new Character(new Settings(true), "Test", new Human(), new Craftsman());
        var armor = new LeatherArmor();
        character.Equipment.Add(armor);
        character.Armor = armor;

        var json = JsonConvert.SerializeObject(character, settings);
        var reloaded = JsonConvert.DeserializeObject<Character>(json, settings);

        Assert.That(reloaded, Is.Not.Null);
        Assert.That(reloaded!.Armor, Is.Not.Null, "Armor was lost during round-trip.");
        Assert.That(reloaded.Armor, Is.InstanceOf<LeatherArmor>());
    }

    [Test]
    public void Character_WithArmorEquippedButNotInEquipment_RoundTripsArmorAfterSerialization()
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            SerializationBinder = new LegacyAssemblySerializationBinder(),
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        };

        var character = new Character(new Settings(true), "Test", new Human(), new Craftsman());
        var armor = new LeatherArmor();
        character.Armor = armor;

        var json = JsonConvert.SerializeObject(character, settings);
        var reloaded = JsonConvert.DeserializeObject<Character>(json, settings);

        Assert.That(reloaded, Is.Not.Null);
        Assert.That(reloaded!.Armor, Is.Not.Null, "Armor was lost during round-trip.");
    }
}
