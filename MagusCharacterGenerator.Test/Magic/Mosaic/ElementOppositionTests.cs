using MAGUS.GameSystem.Magic.ElementalMagic;

namespace MAGUS.Test.Magic.Mosaic;

[TestFixture]
public class ElementOppositionTests
{
    [TestCase(OsElementType.Fire, OsElementType.Water, true)]
    [TestCase(OsElementType.Water, OsElementType.Fire, true)]
    [TestCase(OsElementType.Earth, OsElementType.Air, true)]
    [TestCase(OsElementType.Fire, OsElementType.Earth, false)]
    public void AreOpposite_PrimalElements(OsElementType a, OsElementType b, bool expected)
    {
        var elementA = new CreatedElement { OsElement = a, Strength = 1, Damage = 1 };
        var elementB = new CreatedElement { OsElement = b, Strength = 1, Damage = 1 };
        Assert.That(ElementOpposition.AreOpposite(elementA, elementB), Is.EqualTo(expected));
    }

    [TestCase(ParaElementType.Heat, ParaElementType.Frost, true)]
    [TestCase(ParaElementType.Light, ParaElementType.Darkness, true)]
    [TestCase(ParaElementType.Heat, ParaElementType.Light, false)]
    public void AreOpposite_ParaElements(ParaElementType a, ParaElementType b, bool expected)
    {
        var elementA = new CreatedElement { ParaElement = a, Strength = 1 };
        var elementB = new CreatedElement { ParaElement = b, Strength = 1 };
        Assert.That(ElementOpposition.AreOpposite(elementA, elementB), Is.EqualTo(expected));
    }

    [Test]
    public void AreOpposite_MixedPrimalAndPara_IsFalse()
    {
        var primal = new CreatedElement { OsElement = OsElementType.Fire, Strength = 1, Damage = 1 };
        var para = new CreatedElement { ParaElement = ParaElementType.Frost, Strength = 1 };
        Assert.That(ElementOpposition.AreOpposite(primal, para), Is.False);
    }

    [Test]
    public void Cancel_EqualStrength_BothAnnihilate()
    {
        var fire = new CreatedElement { OsElement = OsElementType.Fire, Strength = 3, Damage = 9 };
        var water = new CreatedElement { OsElement = OsElementType.Water, Strength = 3, Damage = 9 };

        Assert.That(ElementOpposition.Cancel(fire, water), Is.Null);
    }

    [Test]
    public void Cancel_UnequalStrength_StrongerSurvivesReduced()
    {
        var fire = new CreatedElement { OsElement = OsElementType.Fire, Strength = 5, Damage = 15 };
        var water = new CreatedElement { OsElement = OsElementType.Water, Strength = 2, Damage = 6 };

        var result = ElementOpposition.Cancel(fire, water);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.OsElement, Is.EqualTo(OsElementType.Fire));
        Assert.That(result.Strength, Is.EqualTo(3));
    }

    [Test]
    public void Cancel_NotOpposite_Throws()
    {
        var fire = new CreatedElement { OsElement = OsElementType.Fire, Strength = 1, Damage = 1 };
        var earth = new CreatedElement { OsElement = OsElementType.Earth, Strength = 1, Damage = 1 };

        Assert.That(() => ElementOpposition.Cancel(fire, earth), Throws.ArgumentException);
    }
}
