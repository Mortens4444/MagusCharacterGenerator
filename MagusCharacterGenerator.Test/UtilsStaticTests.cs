using MAGUS.Enums;
using MAGUS.Races;
using MAGUS.Things.Food;
using MAGUS.Things.MagicalObjects;
using MAGUS.Utils;

namespace MAGUS.Test;

[TestFixture]
public class ScaleTests
{
    [Test]
    public void GetWeight_KnownType_ReturnsMappedWeight()
    {
        Assert.That(Scale.GetWeight(new LunchDinner()), Is.EqualTo(0.5));
    }

    [Test]
    public void GetWeight_UnmappedTypeWithWeightProperty_UsesReflection()
    {
        var thing = new StaffOfNecromancers();
        var weight = Scale.GetWeight(thing);
        Assert.That(weight, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void GetWeight_Null_Throws()
    {
        Assert.That(() => Scale.GetWeight(null!), Throws.ArgumentNullException);
    }
}

[TestFixture]
public class LaboratoryTests
{
    [Test]
    public void GetPoisonEffects_ReturnsEffectsForEveryKnownType()
    {
        foreach (PoisonType type in Enum.GetValues<PoisonType>())
        {
            var effects = Laboratory.GetPoisonEffects(type);
            Assert.That(effects, Is.Not.Null);
        }
    }
}

[TestFixture]
public class NameGeneratorTests
{
    [Test]
    public void Get_WithRace_UsesRaceGenerator()
    {
        var name = NameGenerator.Get(new Human());
        Assert.That(name, Is.Not.Null);
    }

    [Test]
    public void Get_WithNullRace_FallsBackToHuman()
    {
        var name = NameGenerator.Get(null);
        Assert.That(name, Is.Not.Null);
    }

    [TestCase("")]
    [TestCase("   ")]
    [TestCase(null)]
    [TestCase("Fire_Arrow_2")]
    [TestCase("already nice")]
    [TestCase("123")]
    public void ToName_HandlesVariousInputs(string? input)
    {
        var result = input!.ToName();
        Assert.That(result, Is.Not.Null);
    }
}

[TestFixture]
public class RuneTranslatorTests
{
    private readonly RuneTranslator translator = new();

    [TestCase("")]
    [TestCase("   ")]
    [TestCase(null)]
    [TestCase("Hello World")]
    [TestCase("Árvíztűrő tükörfúrógép")]
    public void ToRunes_HandlesVariousInputs(string? input)
    {
        var result = translator.ToRunes(input!);
        Assert.That(result, Is.Not.Null);
    }

    [TestCase("")]
    [TestCase("   ")]
    [TestCase(null)]
    public void ToPlain_HandlesEmptyInputs(string? input)
    {
        var result = translator.ToPlain(input!);
        Assert.That(result, Is.EqualTo(String.Empty));
    }

    [Test]
    public void RoundTrip_ToRunesAndBack_ProducesReadableOutput()
    {
        var runes = translator.ToRunes("Hello World 123");
        var plain = translator.ToPlain(runes);
        Assert.That(plain, Is.Not.Null);
    }
}

[TestFixture]
public class QualificationLearnerTests
{
    [Test]
    public void Get_ReturnsPopulatedList()
    {
        var qualifications = MAGUS.Qualifications.QualificationLearner.Get();
        Assert.That(qualifications, Is.Not.Empty);
    }
}
