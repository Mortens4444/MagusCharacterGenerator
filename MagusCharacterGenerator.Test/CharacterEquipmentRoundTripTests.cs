using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.GameSystem;
using MAGUS.Races;
using MAGUS.Things.Weapons.CrushingWeapons;
using MAGUS.Utils;
using Newtonsoft.Json;

namespace MAGUS.Test;

/// <summary>
/// Diagnostic for the reported "primary weapon is forgotten after reload" bug: mirrors
/// CharacterRepository's exact save/load path (same JsonSerializerSettings) with a weapon that -
/// like the real Market/PreloadService flow - is a single shared prototype instance handed to
/// Character.Buy rather than a fresh clone per purchase.
/// </summary>
[TestFixture]
public class CharacterEquipmentRoundTripTests
{
    private static readonly JsonSerializerSettings JsonSettings = new()
    {
        TypeNameHandling = TypeNameHandling.Auto,
        SerializationBinder = new LegacyAssemblySerializationBinder(),
        PreserveReferencesHandling = PreserveReferencesHandling.Objects
    };

    [Test]
    public void PrimaryWeapon_SurvivesSaveLoadRoundTrip_WithSharedPrototypeInstance()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Craftsman())
        {
            Money = new MAGUS.GameSystem.Valuables.Money(9999)
        };
        var catalogWeapon = new ShortStaff(); // stands in for a PreloadService.Instance.Things prototype
        character.Buy(catalogWeapon);
        character.PrimaryWeapon = catalogWeapon;

        var json = JsonConvert.SerializeObject(character, JsonSettings);
        var reloaded = JsonConvert.DeserializeObject<Character>(json, JsonSettings)!;
        reloaded.SetWeapons();

        Assert.That(reloaded.PrimaryWeaponId, Is.EqualTo(catalogWeapon.Id), "PrimaryWeaponId itself should survive the round trip.");
        Assert.That(reloaded.PrimaryWeapon, Is.Not.Null, "PrimaryWeapon should resolve after reload.");
        Assert.That(reloaded.PrimaryWeapon!.Id, Is.EqualTo(catalogWeapon.Id));
    }
}
