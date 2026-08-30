using MAGUS.Interfaces;
using MAGUS.Things.MagicalObjects;

namespace MAGUS.Test;

/// <summary>
/// PreloadService.LoadMagicalObjectsAsync reflects over every concrete MagicalObject and constructs
/// it with its parameterless constructor to build the "Magic items" reference catalog, touching Name
/// immediately afterward (OrderBy(m => Lng.Elem(m.Name))) - a bare GemstoneWeapon (no TargetItem or
/// Gemstone set, since only Character.TryCraftGemstoneWeapon ever does that) used to throw a
/// NullReferenceException there. Covers both fixes: the properties tolerate a bare instance, and
/// INotForSale keeps it out of that reflection scan in the first place (see
/// PreloadService.LoadMagicalObjectsAsync's typeof(INotForSale) exclusion).
/// </summary>
[TestFixture]
public class GemstoneWeaponTests
{
    [Test]
    public void IsNotForSale()
    {
        Assert.That(new GemstoneWeapon(), Is.InstanceOf<INotForSale>());
    }

    [Test]
    public void BareInstance_DoesNotThrow_WhenAccessingDisplayProperties()
    {
        var gemstoneWeapon = new GemstoneWeapon();

        Assert.Multiple(() =>
        {
            Assert.DoesNotThrow(() => _ = gemstoneWeapon.Name);
            Assert.DoesNotThrow(() => _ = gemstoneWeapon.Description);
            Assert.DoesNotThrow(() => _ = gemstoneWeapon.Weight);
            Assert.DoesNotThrow(() => _ = gemstoneWeapon.Price);
        });
    }
}
