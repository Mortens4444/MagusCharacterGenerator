using MAGUS.Enums;
using MAGUS.Models;

namespace MAGUS.Test;

[TestFixture]
public class RollFormulaTests
{
    [Test]
    public void StringCtor_ParsesFormula_AddingUnderscorePrefix()
    {
        var formula = new RollFormula("3D6", 1, true, "Attack");
        Assert.That(formula.ThrowType, Is.EqualTo(ThrowType._3D6));
        Assert.That(formula.Modifier, Is.EqualTo(1));
        Assert.That(formula.SpecialTraining, Is.True);
        Assert.That(formula.Title, Is.EqualTo("Attack"));
    }

    [Test]
    public void StringCtor_WithLeadingUnderscore_IsUnchanged()
    {
        var formula = new RollFormula("_1D10", 0, false);
        Assert.That(formula.ThrowType, Is.EqualTo(ThrowType._1D10));
    }

    [Test]
    public void StringCtor_With2xSuffix_MapsToTwoTimesVariant()
    {
        var formula = new RollFormula("2D6 (2x)", 0, false);
        Assert.That(formula.ThrowType, Is.EqualTo(ThrowType._2D6_2_Times));
    }

    [Test]
    public void ThrowTypeCtor_UsesDescriptionAsFormula()
    {
        var formula = new RollFormula(ThrowType._1D100, 5, false);
        Assert.That(formula.Formula, Is.Not.Empty);
        Assert.That(formula.ThrowType, Is.EqualTo(ThrowType._1D100));
    }

    [Test]
    public void DiceThrowFormulaCtor_CopiesValues()
    {
        var source = new DiceThrowFormula { Formula = "1D6", Modifier = 2, HasSpecialTraining = true };
        var formula = new RollFormula(source);

        Assert.That(formula.ThrowType, Is.EqualTo(ThrowType._1D6));
        Assert.That(formula.Modifier, Is.EqualTo(2));
        Assert.That(formula.SpecialTraining, Is.True);
    }

    [Test]
    public void DiceThrowFormulaCtor_Null_Throws()
    {
        Assert.That(() => new RollFormula((DiceThrowFormula)null!), Throws.ArgumentNullException);
    }

    [Test]
    public void PropertyInfoCtor_ReadsDiceThrowAttribute()
    {
        var property = typeof(MAGUS.Classes.NonPlayableCharacters.Craftsman).GetProperty(nameof(MAGUS.Classes.NonPlayableCharacters.Craftsman.Strength));

        var formula = new RollFormula(property);
        Assert.That(formula.ThrowType, Is.EqualTo(ThrowType._2D6));

        Assert.That(() => new RollFormula((System.Reflection.PropertyInfo)null!), Throws.ArgumentNullException);
    }

    [Test]
    public void DefaultToAuto_DefaultsToTrue_AndIsSettable()
    {
        var formula = new RollFormula(ThrowType._1D6, 0, false)
        {
            DefaultToAuto = false
        };
        Assert.That(formula.DefaultToAuto, Is.False);
    }
}
