using MAGUS.Enums;
using MAGUS.GameSystem.Magic.ElementalMagic;
using MAGUS.GameSystem.Magic.ElementalMagic.CreationMosaics;

namespace MAGUS.Test.Magic.Mosaic;

[TestFixture]
public class MosaicArrowSpellTests
{
    [Test]
    public void ImplementsISpell_WithExpectedValues()
    {
        var creation = new PrimalElementCreation();
        var element = new CreatedElement { OsElement = OsElementType.Fire, Strength = 3, Damage = 11 };
        var spell = new MosaicArrowSpell(creation, element);

        Assert.That(spell.School, Is.EqualTo(MagicSchool.Mosaic));
        Assert.That(spell.Power, Is.Null);
        Assert.That(spell.ManaCost, Is.EqualTo(12));
        Assert.That(spell.CastingTimeInSegments, Is.EqualTo(1));
        Assert.That(spell.DurationInRounds, Is.EqualTo(1));
        Assert.That(spell.GetDamage(), Is.EqualTo(11));
        Assert.That(spell.Name, Does.Contain("Arrow"));
    }

    [Test]
    public void ManaCost_TracksTheCreationMosaicsFormula()
    {
        var creation = new HeatCreation();
        var element = creation.Create(4);
        var spell = new MosaicArrowSpell(creation, element);

        Assert.That(spell.ManaCost, Is.EqualTo(8));
    }
}

[TestFixture]
public class MosaicSwordSpellTests
{
    [Test]
    public void ImplementsISpell_WithExpectedValues()
    {
        var creation = new PrimalElementCreation();
        var element = new CreatedElement { OsElement = OsElementType.Earth, Strength = 2, Damage = 6 };
        var weapon = new FixedDamageWeapon(4);
        var spell = new MosaicSwordSpell(creation, element, weapon);

        Assert.That(spell.School, Is.EqualTo(MagicSchool.Mosaic));
        Assert.That(spell.Power, Is.Null);
        Assert.That(spell.ManaCost, Is.EqualTo(8));
        Assert.That(spell.DurationInRounds, Is.EqualTo(5));
        Assert.That(spell.GetDamage(), Is.EqualTo(10));
        Assert.That(spell.Name, Does.Contain("Sword"));
    }
}

[TestFixture]
public class ElementalMagicCatalogTests
{
    [Test]
    public void CreationMosaics_ContainsAllSix()
    {
        Assert.That(ElementalMagicCatalog.CreationMosaics, Has.Count.EqualTo(6));
    }

    [Test]
    public void Forms_ContainsAllTen()
    {
        Assert.That(ElementalMagicCatalog.Forms, Has.Count.EqualTo(10));
    }
}
