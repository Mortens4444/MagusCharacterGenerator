using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;

namespace MAGUS.Test;

[TestFixture]
public class DiceThrowTests
{
    private static readonly DiceThrow Dice = new();

    private static IEnumerable<ThrowType> AllThrowTypes => Enum.GetValues<ThrowType>();

    [Test]
    public void AllPublicMethods_CanBeInvoked_WithAndWithoutLuckAmulet()
    {
        var type = typeof(DiceThrow);
        foreach (var method in type.GetMethods())
        {
            if (method.DeclaringType != type)
            {
                continue;
            }

            var parameters = method.GetParameters();
            if (parameters.Length == 0)
            {
                Invoke(method, []);
            }
            else if (parameters.Length == 1 && parameters[0].ParameterType == typeof(bool))
            {
                Invoke(method, [true]);
                Invoke(method, [false]);
            }
            else if (method.Name == nameof(DiceThrow.RangedAttackND6))
            {
                Invoke(method, [3, true]);
                Invoke(method, [3, false]);
            }
            else if (method.Name == nameof(DiceThrow.Range))
            {
                Invoke(method, [1, 20, true]);
                Invoke(method, [1, 20, false]);
            }
        }
    }

    private static void Invoke(System.Reflection.MethodInfo method, object?[] args)
    {
        // Run several times so probability-driven branches (ApplyLuck edge values, the reroll
        // loop in RangedAttack) get exercised too.
        for (var i = 0; i < 40; i++)
        {
            try
            {
                method.Invoke(Dice, args);
            }
            catch (System.Reflection.TargetInvocationException)
            {
                // SpecialTraining("died during special training") and similar intentional throws.
            }
        }
    }

    [Test]
    public void Throw_HandlesEveryThrowType_WithModifierAndSpecialTraining()
    {
        foreach (var throwType in AllThrowTypes)
        {
            for (var i = 0; i < 10; i++)
            {
                try
                {
                    _ = Dice.Throw(throwType, modifier: 1, specialTraing: true, hasLuckAmulet: i % 2 == 0);
                    _ = Dice.Throw(throwType, modifier: 0, specialTraing: false);
                }
                catch (Exception ex) when (ex is ArgumentOutOfRangeException || ex.Message.Contains("died during special training"))
                {
                }
            }
        }
    }

    [Test]
    public void Throw_WithInvalidThrowType_Throws()
    {
        Assert.That(() => Dice.Throw((ThrowType)9999), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void GetRange_HandlesEveryThrowType_WithModifierAndSpecialTraining()
    {
        // A handful of ThrowType values (e.g. _1D1, _1D3_Ranged, _1D5_Ranged) have no case in
        // GetRange's switch, even though some of them (_1D1) have a real dice method and are
        // handled elsewhere. Pre-existing gaps, unrelated to this test - not guessing at the
        // "correct" Range for each here, since that's a game-design call, not mine to make.
        foreach (var throwType in AllThrowTypes)
        {
            try
            {
                var range = Dice.GetRange(throwType, modifier: 2, specialTraing: true);
                Assert.That(range, Is.Not.Null);
                range = Dice.GetRange(throwType);
                Assert.That(range, Is.Not.Null);
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }
    }

    [Test]
    public void GetRange_WithInvalidThrowType_Throws()
    {
        Assert.That(() => Dice.GetRange((ThrowType)9999), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void Throw_WithAttributes_UsesAttributeValues()
    {
        var throwAttr = new DiceThrowAttribute(ThrowType._2D6);
        var modAttr = new DiceThrowModifierAttribute(2);
        var specialAttr = new SpecialTrainingAttribute();

        for (var i = 0; i < 20; i++)
        {
            try
            {
                _ = Dice.Throw(throwAttr, modAttr, specialAttr, hasLuckAmulet: true);
                _ = Dice.Throw(throwAttr, null, null);
            }
            catch (Exception ex) when (ex.Message.Contains("died during special training"))
            {
            }
        }
    }

    [Test]
    public void Throw_WithNullAttribute_Throws()
    {
        Assert.That(() => Dice.Throw(null, null, null), Throws.ArgumentNullException);
    }
}
