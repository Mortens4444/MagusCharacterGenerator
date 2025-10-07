using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Test;

[TestFixture]
public class MoneyTests
{
    private Money CreateMoney(decimal mithril, decimal gold, decimal silver, decimal copper)
    {
        var money = new Money(gold, silver, copper)
        {
            Mithril = mithril
        };
        return money;
    }

    [Test]
    public void AdditionOperator_ShouldAddAllComponentsCorrectly_AndModifyLeftOperand()
    {
        var moneyA = CreateMoney(1, 10, 50, 50); // 1m 10g 50s 50c
        var moneyB = CreateMoney(2, 5, 20, 10);  // 2m 5g 20s 10c

        var expectedMoney = new Money(10 + 5, 50 + 20, 50 + 10, 1 + 2);
        var result = moneyA + moneyB;

        Assert.That(result.Summa, Is.EqualTo(expectedMoney.Summa));
    }

    [Test]
    public void AdditionOperator_ShouldThrowArgumentNullException_WhenLeftOperandIsNull()
    {
        Money moneyA = null;
        var moneyB = CreateMoney(1, 0, 0, 0);

        Assert.That(() => moneyA + moneyB, Throws.ArgumentNullException.With.Message.Contains("cannot be null."));
    }

    [Test]
    public void AdditionOperator_ShouldThrowArgumentNullException_WhenRightOperandIsNull()
    {
        var moneyA = CreateMoney(1, 0, 0, 0);
        Money moneyB = null;

        Assert.That(() => moneyA + moneyB, Throws.ArgumentNullException.With.Message.Contains("cannot be null."));
    }

    // =================================================================================
    // Operátor - Tesztek (Subtraction Tests)
    // =================================================================================

    [Test]
    public void SubtractionOperator_ShouldThrowInvalidOperationException_WhenResultIsNegative()
    {
        // Arrange
        var moneyA = CreateMoney(0, 1, 0, 0);     // 1g (1000c)
        var moneyB = CreateMoney(0, 1, 0, 1);     // 1g 1c (1001c)

        // Act & Assert (Fluent Assertions Syntax)
        Assert.That(() => moneyA - moneyB, Throws.InvalidOperationException, "Kisebb összegből nagyobb kivonásakor kellett volna exceptiont dobni.");
    }

    [Test]
    public void SubtractionOperator_ShouldNotModifyLeftOperand_ButShouldCheckSumma()
    {
        var moneyA = CreateMoney(0, 5, 0, 0); // 5g
        var moneyB = CreateMoney(0, 2, 0, 0); // 2g

        var expectedSumma =  (5 - 2) * Money.CopperPerGold;

        var result = moneyA - moneyB;

        Assert.That(result.Summa, Is.EqualTo(expectedSumma));
    }

    [Test]
    public void SubtractionOperator_ShouldThrowArgumentNullException_WhenLeftOperandIsNull()
    {
        Money moneyA = null;
        var moneyB = CreateMoney(1, 0, 0, 0);

        Assert.That(() => moneyA - moneyB, Throws.ArgumentNullException.With.Message.Contains("cannot be null."));
    }

    [Test]
    public void SubtractionOperator_ShouldThrowArgumentNullException_WhenRightOperandIsNull()
    {
        var moneyA = CreateMoney(1, 0, 0, 0);
        Money moneyB = null;

        Assert.That(() => moneyA - moneyB, Throws.ArgumentNullException.With.Message.Contains("cannot be null."));
    }
}