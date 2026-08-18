using MAGUS.Enums;
using MAGUS.Models;
using MAGUS.Services;

namespace MAGUS.Test;

[TestFixture]
public class AutoCombatRollServiceTests
{
    private readonly AutoCombatRollService service = new();

    [Test]
    public async Task RollAsync_ThrowType_ReturnsPositiveValue()
    {
        var result = await service.RollAsync(ThrowType._1D6, "title");
        Assert.That(result, Is.GreaterThan(0));
    }

    [Test]
    public async Task RollAsync_RollFormula_ReturnsValue()
    {
        var formula = new RollFormula(ThrowType._1D6, 0, false);
        var result = await service.RollAsync(formula, "title");
        Assert.That(result, Is.GreaterThan(0));
    }

    [Test]
    public async Task RollAsync_DiceThrowFormula_ReturnsValue()
    {
        var formula = new DiceThrowFormula { Formula = "1D6", Modifier = 0, HasSpecialTraining = false };
        var result = await service.RollAsync(formula, "title");
        Assert.That(result, Is.GreaterThan(0));
    }
}

[TestFixture]
public class HorseQualityResultTests
{
    [Test]
    public void RollHorseQuality_CoversEveryOutcome()
    {
        var seenQualities = new HashSet<HorseQuality>();
        for (var i = 0; i < 2000 && seenQualities.Count < 12; i++)
        {
            var result = HorseQualityResult.RollHorseQuality();
            Assert.That(result, Is.Not.Null);
            seenQualities.Add(result.Quality);
        }

        Assert.That(seenQualities, Is.Not.Empty);
    }
}
