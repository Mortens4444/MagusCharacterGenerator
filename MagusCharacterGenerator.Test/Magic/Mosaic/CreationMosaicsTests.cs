using MAGUS.GameSystem.Magic.ElementalMagic;
using MAGUS.GameSystem.Magic.ElementalMagic.CreationMosaics;

namespace MAGUS.Test.Magic.Mosaic;

[TestFixture]
public class PrimalElementCreationTests
{
    private readonly PrimalElementCreation mosaic = new();

    [TestCase(1, 4)]
    [TestCase(2, 8)]
    [TestCase(5, 20)]
    public void GetManaCost_ScalesByFourPerStrength(int strength, int expectedManaCost)
    {
        Assert.That(mosaic.GetManaCost(strength), Is.EqualTo(expectedManaCost));
    }

    [TestCase(0)]
    [TestCase(-1)]
    public void GetManaCost_InvalidStrength_Throws(int strength)
    {
        Assert.That(() => mosaic.GetManaCost(strength), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void Create_RollsDamageInRangeOfStrengthDice()
    {
        const int strength = 4;
        for (var i = 0; i < 50; i++)
        {
            var element = mosaic.Create(OsElementType.Fire, strength);
            Assert.That(element.OsElement, Is.EqualTo(OsElementType.Fire));
            Assert.That(element.Strength, Is.EqualTo(strength));
            Assert.That(element.Damage, Is.InRange(strength, strength * 6));
        }
    }

    [Test]
    public void Create_InvalidStrength_Throws()
    {
        Assert.That(() => mosaic.Create(OsElementType.Water, 0), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void CastingTimeInSegments_IsOne()
    {
        Assert.That(mosaic.CastingTimeInSegments, Is.EqualTo(1));
    }
}

[TestFixture]
public class HeatCreationTests
{
    private readonly HeatCreation mosaic = new();

    [TestCase(1, 2)]
    [TestCase(3, 6)]
    public void GetManaCost_ScalesByTwoPerStrength(int strength, int expectedManaCost)
    {
        Assert.That(mosaic.GetManaCost(strength), Is.EqualTo(expectedManaCost));
    }

    [TestCase(1, 10)]
    [TestCase(4, 40)]
    public void GetTemperatureIncrease_IsTenPerStrength(int strength, int expectedDelta)
    {
        Assert.That(mosaic.GetTemperatureIncrease(strength), Is.EqualTo(expectedDelta));
    }

    [TestCase(99, 0)]
    [TestCase(100, 2)]
    [TestCase(110, 4)]
    [TestCase(120, 6)]
    public void GetDamage_AppliesOnlyAtOrAboveThreshold(int resultingTemperature, int expectedDamage)
    {
        Assert.That(mosaic.GetDamage(resultingTemperature), Is.EqualTo(expectedDamage));
    }

    [Test]
    public void Create_ProducesHeatParaElement()
    {
        var element = mosaic.Create(2);
        Assert.That(element.ParaElement, Is.EqualTo(ParaElementType.Heat));
        Assert.That(element.Strength, Is.EqualTo(2));
    }

    [Test]
    public void CastingTimeInSegments_IsTwo()
    {
        Assert.That(mosaic.CastingTimeInSegments, Is.EqualTo(2));
    }
}

[TestFixture]
public class FrostCreationTests
{
    private readonly FrostCreation mosaic = new();

    [TestCase(1, 2)]
    [TestCase(3, 6)]
    public void GetManaCost_ScalesByTwoPerStrength(int strength, int expectedManaCost)
    {
        Assert.That(mosaic.GetManaCost(strength), Is.EqualTo(expectedManaCost));
    }

    [TestCase(1, 10)]
    [TestCase(4, 40)]
    public void GetTemperatureDecrease_IsTenPerStrength(int strength, int expectedDelta)
    {
        Assert.That(mosaic.GetTemperatureDecrease(strength), Is.EqualTo(expectedDelta));
    }

    [TestCase(-39, 0)]
    [TestCase(-40, 2)]
    [TestCase(-50, 4)]
    public void GetDamage_AppliesOnlyAtOrBelowThreshold(int resultingTemperature, int expectedDamage)
    {
        Assert.That(mosaic.GetDamage(resultingTemperature), Is.EqualTo(expectedDamage));
    }

    [Test]
    public void Create_ProducesFrostParaElement()
    {
        var element = mosaic.Create(3);
        Assert.That(element.ParaElement, Is.EqualTo(ParaElementType.Frost));
    }
}

[TestFixture]
public class LightCreationTests
{
    private readonly LightCreation mosaic = new();

    [TestCase(1, 2)]
    [TestCase(10, 20)]
    public void GetManaCost_ScalesByTwoPerStrength(int strength, int expectedManaCost)
    {
        Assert.That(mosaic.GetManaCost(strength), Is.EqualTo(expectedManaCost));
    }

    [Test]
    public void Create_ProducesLightParaElement_WithNoDamage()
    {
        var element = mosaic.Create(5);
        Assert.That(element.ParaElement, Is.EqualTo(ParaElementType.Light));
        Assert.That(element.Damage, Is.EqualTo(0));
    }

    [TestCase(1, "matchstick flame")]
    [TestCase(8, "campfire light")]
    [TestCase(15, "blinding light")]
    [TestCase(25, "permanent blindness if the eyes are open")]
    public void GetDescription_MapsStrengthToLightSource(int strength, string expectedDescription)
    {
        Assert.That(mosaic.GetDescription(strength), Is.EqualTo(expectedDescription));
    }
}

[TestFixture]
public class DarknessCreationTests
{
    private readonly DarknessCreation mosaic = new();

    [Test]
    public void Create_ProducesDarknessParaElement()
    {
        var element = mosaic.Create(2);
        Assert.That(element.ParaElement, Is.EqualTo(ParaElementType.Darkness));
    }

    [TestCase(1, "dusk")]
    [TestCase(9, "pitch dark")]
    [TestCase(11, "even ultravision and infravision fail")]
    [TestCase(50, "even ultravision and infravision fail")]
    public void GetDescription_MapsStrengthToDarknessLevel(int strength, string expectedDescription)
    {
        Assert.That(mosaic.GetDescription(strength), Is.EqualTo(expectedDescription));
    }
}

[TestFixture]
public class ElementalForceCreationTests
{
    private readonly ElementalForceCreation mosaic = new();

    [TestCase(1, 1)]
    [TestCase(5, 5)]
    public void GetManaCost_IsOnePerStrength(int strength, int expectedManaCost)
    {
        Assert.That(mosaic.GetManaCost(strength), Is.EqualTo(expectedManaCost));
    }

    [Test]
    public void Create_ProducesElementalForce()
    {
        var element = mosaic.Create(3);
        Assert.That(element.IsElementalForce, Is.True);
        Assert.That(element.OsElement, Is.Null);
        Assert.That(element.ParaElement, Is.Null);
    }

    [TestCase(ObjectSpeed.Stationary, 5)]
    [TestCase(ObjectSpeed.Walking, 2.5)]
    [TestCase(ObjectSpeed.Running, 1)]
    [TestCase(ObjectSpeed.Galloping, 0.5)]
    public void GetMaxHeldWeightKg_MatchesSpeedTable(ObjectSpeed speed, double expectedKg)
    {
        Assert.That(mosaic.GetMaxHeldWeightKg(1, speed), Is.EqualTo(expectedKg));
    }

    [Test]
    public void GetMaxHeldWeightKg_InvalidSpeed_Throws()
    {
        Assert.That(() => mosaic.GetMaxHeldWeightKg(1, (ObjectSpeed)999), Throws.TypeOf<ArgumentOutOfRangeException>());
    }
}
