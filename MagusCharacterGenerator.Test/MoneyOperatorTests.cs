using MAGUS.GameSystem.Valuables;

namespace MAGUS.Test;

[TestFixture]
public class MoneyOperatorTests
{
    [Test]
    public void CompareTo_OtherMoney_ComparesBySumma()
    {
        var small = new Money(1);
        var big = new Money(2);

        Assert.That(small.CompareTo(big), Is.LessThan(0));
        Assert.That(big.CompareTo(small), Is.GreaterThan(0));
        Assert.That(small.CompareTo(small), Is.EqualTo(0));
        Assert.That(small.CompareTo(null), Is.EqualTo(1));
    }

    [Test]
    public void CompareTo_CopperAmount_ComparesBySumma()
    {
        var money = new Money(0, 0, 500);
        Assert.That(money.CompareTo(500ul), Is.EqualTo(0));
        Assert.That(money.IsAtLeast(499ul), Is.True);
        Assert.That(money.IsAtLeast(501ul), Is.False);
    }

    [Test]
    public void Equals_And_HashCode_MatchOnSameSumma()
    {
        var a = new Money(1, 2, 3);
        var b = new Money(1, 2, 3);

        Assert.That(a.Equals(b), Is.True);
        Assert.That(a.Equals((object)b), Is.True);
        Assert.That(a.Equals(null), Is.False);
        Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
    }

    [Test]
    public void ComparisonOperators_BehaveConsistently()
    {
        var small = new Money(1);
        var big = new Money(2);

        Assert.That(small == new Money(1), Is.True);
        Assert.That(small != big, Is.True);
        Assert.That(small < big, Is.True);
        Assert.That(big > small, Is.True);
        Assert.That(small <= new Money(1), Is.True);
        Assert.That(big >= new Money(1), Is.True);
        var sameInstance = small;
        Assert.That(small == sameInstance, Is.True);
        Assert.That(small <= sameInstance, Is.True);
        Assert.That(small >= sameInstance, Is.True);
    }

    [Test]
    public void ToString_ProducesReadableFormat()
    {
        var money = new Money(1, 2, 3) { Mithril = 4 };
        Assert.That(money.ToString(), Is.EqualTo("4m 1g 2s 3c"));
    }

    [Test]
    public void MultiplyOperator_ScalesSumma()
    {
        var money = new Money(10);
        var doubled = money * 2.0;
        Assert.That(doubled.Summa, Is.EqualTo(money.Summa * 2));
    }

    [Test]
    public void MultiplyOperator_Null_Throws()
    {
        Money? money = null;
        Assert.That(() => money! * 2.0, Throws.ArgumentNullException);
    }

    [Test]
    public void DoubleIt_ReturnsSumOfMoneyWithItself()
    {
        var money = new Money(5);
        var doubled = Money.DoubleIt(money);
        Assert.That(doubled.Summa, Is.EqualTo(money.Summa * 2));
    }

    [Test]
    public void IsZero_TrueOnlyWhenAllComponentsAreZero()
    {
        Assert.That(Money.Free.IsZero, Is.True);
        Assert.That(new Money(1).IsZero, Is.False);
    }
}
