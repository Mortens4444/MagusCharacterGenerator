using MAGUS.GameSystem.Magic.ElementalMagic;
using MAGUS.GameSystem.Magic.ElementalMagic.Forms;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;
using MAGUS.Models;

namespace MAGUS.Test.Magic.Mosaic;

internal sealed class FixedDamageWeapon(int damage) : IWeapon
{
    public string Name => "Fixed Damage Weapon";

    public double AttacksPerRound => 1;

    public int InitiateValue => 0;

    public double Weight => 1;

    public Money Price => new(0);

    public DiceThrowFormula? DamageFormula => null;

    public int GetDamage() => damage;
}

[TestFixture]
public class ArrowTests
{
    private readonly Arrow arrow = new();

    [Test]
    public void GetDamage_EqualsElementDamage()
    {
        var element = new CreatedElement { OsElement = OsElementType.Fire, Strength = 3, Damage = 12 };
        Assert.That(arrow.GetDamage(element), Is.EqualTo(12));
    }

    [Test]
    public void DurationInRounds_IsInstantaneous()
    {
        Assert.That(arrow.DurationInRounds, Is.EqualTo(0));
    }
}

[TestFixture]
public class SwordTests
{
    private readonly Sword sword = new();

    [Test]
    public void GetDamage_AddsWeaponAndElementDamage()
    {
        IWeapon weapon = new FixedDamageWeapon(5);
        var element = new CreatedElement { OsElement = OsElementType.Fire, Strength = 2, Damage = 7 };

        Assert.That(sword.GetDamage(element, weapon), Is.EqualTo(12));
    }

    [Test]
    public void DurationInRounds_IsFive()
    {
        Assert.That(sword.DurationInRounds, Is.EqualTo(5));
    }
}

[TestFixture]
public class BurstTests
{
    private readonly Burst burst = new();

    [Test]
    public void GetRadiusFeet_EqualsElementStrength()
    {
        var element = new CreatedElement { OsElement = OsElementType.Fire, Strength = 6, Damage = 20 };
        Assert.That(burst.GetRadiusFeet(element), Is.EqualTo(6));
    }

    [TestCase(0, 20)]
    [TestCase(5, 15)]
    [TestCase(25, 0)]
    public void GetDamageAtDistance_FallsOffByOnePerFoot(int distance, int expectedDamage)
    {
        var element = new CreatedElement { OsElement = OsElementType.Fire, Strength = 6, Damage = 20 };
        Assert.That(burst.GetDamageAtDistance(element, distance), Is.EqualTo(expectedDamage));
    }

    [Test]
    public void GetDamageAtDistance_NegativeDistance_Throws()
    {
        var element = new CreatedElement { OsElement = OsElementType.Fire, Strength = 1, Damage = 1 };
        Assert.That(() => burst.GetDamageAtDistance(element, -1), Throws.TypeOf<ArgumentOutOfRangeException>());
    }
}

[TestFixture]
public class CarpetTests
{
    private readonly Carpet carpet = new();

    [TestCase(6, 6, 1)]
    [TestCase(6, 3, 2)]
    [TestCase(6, 2, 3)]
    [TestCase(6, 1, 6)]
    public void GetEffectiveStrength_MatchesBookWorkedExample(int elementStrength, int radiusFeet, int expectedEffectiveStrength)
    {
        var element = new CreatedElement { OsElement = OsElementType.Fire, Strength = elementStrength, Damage = 0 };
        Assert.That(carpet.GetEffectiveStrength(element, radiusFeet), Is.EqualTo(expectedEffectiveStrength));
    }

    [Test]
    public void GetEffectiveStrength_RadiusOutOfRange_Throws()
    {
        var element = new CreatedElement { OsElement = OsElementType.Fire, Strength = 6, Damage = 0 };
        Assert.That(() => carpet.GetEffectiveStrength(element, 0), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => carpet.GetEffectiveStrength(element, 7), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void DurationInRounds_IsThree()
    {
        Assert.That(carpet.DurationInRounds, Is.EqualTo(3));
    }
}

[TestFixture]
public class WallTests
{
    [Test]
    public void GetDamagePerRound_UsesEffectiveStrength()
    {
        var wall = new Wall();
        var element = new CreatedElement { OsElement = OsElementType.Earth, Strength = 8, Damage = 0 };
        Assert.That(wall.GetDamagePerRound(element, 4), Is.EqualTo(2));
    }

    [Test]
    public void DurationInRounds_IsSix()
    {
        Assert.That(new Wall().DurationInRounds, Is.EqualTo(6));
    }
}

[TestFixture]
public class AuraTests
{
    private readonly Aura aura = new();

    [Test]
    public void GetArmorValue_ForElementalForce_EqualsStrength()
    {
        var element = new CreatedElement { IsElementalForce = true, Strength = 4 };
        Assert.That(aura.GetArmorValue(element), Is.EqualTo(4));
    }

    [Test]
    public void GetArmorValue_ForNonElementalForce_Throws()
    {
        var element = new CreatedElement { OsElement = OsElementType.Fire, Strength = 4, Damage = 10 };
        Assert.That(() => aura.GetArmorValue(element), Throws.InvalidOperationException);
    }

    [Test]
    public void DurationInRounds_IsTwo()
    {
        Assert.That(aura.DurationInRounds, Is.EqualTo(2));
    }
}

[TestFixture]
public class ShowerTests
{
    [Test]
    public void GetDamagePerRound_UsesSameFormulaAsCarpet()
    {
        var shower = new Shower();
        var element = new CreatedElement { OsElement = OsElementType.Water, Strength = 9, Damage = 0 };
        Assert.That(shower.GetDamagePerRound(element, 3), Is.EqualTo(3));
    }

    [Test]
    public void DurationInRounds_IsThree()
    {
        Assert.That(new Shower().DurationInRounds, Is.EqualTo(3));
    }
}

[TestFixture]
public class DomeTests
{
    private readonly Dome dome = new();

    [Test]
    public void GetEffectiveStrength_WithParaElement_Works()
    {
        var element = new CreatedElement { ParaElement = ParaElementType.Light, Strength = 4, Damage = 0 };
        Assert.That(dome.GetEffectiveStrength(element, 2), Is.EqualTo(2));
    }

    [Test]
    public void GetEffectiveStrength_WithPrimalElement_Throws()
    {
        var element = new CreatedElement { OsElement = OsElementType.Fire, Strength = 4, Damage = 10 };
        Assert.That(() => dome.GetEffectiveStrength(element, 2), Throws.InvalidOperationException);
    }

    [Test]
    public void GetEffectiveStrength_WithElementalForce_Throws()
    {
        var element = new CreatedElement { IsElementalForce = true, Strength = 4 };
        Assert.That(() => dome.GetEffectiveStrength(element, 2), Throws.InvalidOperationException);
    }

    [Test]
    public void DurationInRounds_IsTwo()
    {
        Assert.That(dome.DurationInRounds, Is.EqualTo(2));
    }
}

[TestFixture]
public class TentTests
{
    [Test]
    public void GetDamagePerRound_UsesEffectiveStrength()
    {
        var tent = new Tent();
        var element = new CreatedElement { OsElement = OsElementType.Air, Strength = 10, Damage = 0 };
        Assert.That(tent.GetDamagePerRound(element, 5), Is.EqualTo(2));
    }

    [Test]
    public void DurationInRounds_IsThree()
    {
        Assert.That(new Tent().DurationInRounds, Is.EqualTo(3));
    }
}

[TestFixture]
public class JetTests
{
    private readonly Jet jet = new();

    [Test]
    public void GetLengthFeet_EqualsElementStrength()
    {
        var element = new CreatedElement { OsElement = OsElementType.Fire, Strength = 5, Damage = 15 };
        Assert.That(jet.GetLengthFeet(element), Is.EqualTo(5));
    }

    [TestCase(0, 15)]
    [TestCase(5, 10)]
    [TestCase(20, 0)]
    public void GetDamageAtDistance_FallsOffByOnePerFoot(int distance, int expectedDamage)
    {
        var element = new CreatedElement { OsElement = OsElementType.Fire, Strength = 5, Damage = 15 };
        Assert.That(jet.GetDamageAtDistance(element, distance), Is.EqualTo(expectedDamage));
    }

    [Test]
    public void GetDamageAtDistance_NegativeDistance_Throws()
    {
        var element = new CreatedElement { OsElement = OsElementType.Fire, Strength = 1, Damage = 1 };
        Assert.That(() => jet.GetDamageAtDistance(element, -1), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void DurationInRounds_IsOne()
    {
        Assert.That(jet.DurationInRounds, Is.EqualTo(1));
    }
}
