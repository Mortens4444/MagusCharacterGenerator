using M.A.G.U.S.GameSystem.Attributes;
using Mtf.Extensions.Services;

namespace M.A.G.U.S.GameSystem;

public class DiceThrow
{
    public int _1D2()
    {
        return RandomProvider.GetSecureRandomByte(1, 3);
    }

    public int _1D3()
    {
        return RandomProvider.GetSecureRandomByte(1, 4);
    }

    public int _1D3_RangedAttack()
    {
        return RangedAttack(1, 4);
    }

    public int _1D5()
    {
        return RandomProvider.GetSecureRandomByte(1, 6);
    }

    public int _1D5_RangedAttack()
    {
        return RangedAttack(1, 6);
    }

    public int _1D6()
    {
        return RandomProvider.GetSecureRandomByte(1, 7);
    }

    public int _1D6_RangedAttack()
    {
        return RangedAttack(1, 7);
    }

    public int _2D6()
    {
        return RandomProvider.GetSecureRandomByte(2, 13);
    }

    public int _2D6_RangedAttack() => RangedAttackND6(2);

    public int _3D6_RangedAttack() => RangedAttackND6(3);
    public int _4D6_RangedAttack() => RangedAttackND6(4);
    public int _5D6_RangedAttack() => RangedAttackND6(5);
    public int _6D6_RangedAttack() => RangedAttackND6(6);
    public int _7D6_RangedAttack() => RangedAttackND6(7);
    public int _8D6_RangedAttack() => RangedAttackND6(8);
    public int _9D6_RangedAttack() => RangedAttackND6(9);
    public int _10D6_RangedAttack() => RangedAttackND6(10);
    public int _11D6_RangedAttack() => RangedAttackND6(11);
    public int _12D6_RangedAttack() => RangedAttackND6(12);
    public int _13D6_RangedAttack() => RangedAttackND6(13);
    public int _14D6_RangedAttack() => RangedAttackND6(14);
    public int _15D6_RangedAttack() => RangedAttackND6(15);

    public int RangedAttackND6(int count)
    {
        var total = 0;
        for (var i = 0; i < count; i++)
        {
            total += RangedAttack(1, 7);
        }
        return total;
    }

    public int _1D6_Plus_10()
    {
        return RandomProvider.GetSecureRandomByte(11, 17);
    }

    public int _1D6_Plus_12()
    {
        return RandomProvider.GetSecureRandomByte(13, 19);
    }

    public int _1D6_Plus_12_Plus_SpecialTraining()
    {
        var baseValue = RandomProvider.GetSecureRandomByte(13, 19);
        return SpecialTraining(baseValue);
    }

    public int _1D6_Plus_14()
    {
        return RandomProvider.GetSecureRandomByte(15, 21);
    }

    public int _1D1()
    {
        if (_1D6() == 6)
        {
            return 1;
        }
        return 0;
    }

    public int _1D9()
    {
        return RandomProvider.GetSecureRandomByte(1, 10);
    }

    public int _1D10()
    {
        return RandomProvider.GetSecureRandomByte(1, 11);
    }

    public int _1D10_RangedAttack()
    {
        return RangedAttack(1, 11);
    }

    public int _2D10()
    {
        return RandomProvider.GetSecureRandomByte(2, 21);
    }

    public int _2D10_RangedAttack()
    {
        return RangedAttack(1, 11) + RangedAttack(1, 11);
    }

    public int _3D10()
    {
        return RandomProvider.GetSecureRandomByte(3, 31);
    }

    public int _1D10_Plus_8()
    {
        return RandomProvider.GetSecureRandomByte(9, 19);
    }

    public int _1D10_Plus_8_2_Times()
    {
        var first = RandomProvider.GetSecureRandomByte(9, 19);
        var second = RandomProvider.GetSecureRandomByte(9, 19);
        return Math.Max(first, second);
    }

    public int _1D10_Plus_8_Plus_SpecialTraining()
    {
        var baseValue = RandomProvider.GetSecureRandomByte(9, 19);
        return SpecialTraining(baseValue);
    }

    public int _1D10_Plus_10()
    {
        return RandomProvider.GetSecureRandomByte(11, 21);
    }

	public int _1D100()
	{
		return RandomProvider.GetSecureRandomByte(1, 101);
	}

	public int _2D100()
	{
		return RandomProvider.GetSecureRandomByte(1, 201);
	}

	public int _3D100()
	{
		return RandomProvider.GetSecureRandomInt(1, 301);
	}

	public int _2D6_Plus_3()
	{
		return RandomProvider.GetSecureRandomByte(5, 16);
	}

	public int _2D6_Plus_6()
    {
        return RandomProvider.GetSecureRandomByte(8, 19);
    }

    public int _2D6_Plus_6_Plus_SpecialTraining()
    {
        var baseValue = RandomProvider.GetSecureRandomByte(8, 19);
        return SpecialTraining(baseValue);
    }

    public int _3D6()
    {
        return RandomProvider.GetSecureRandomByte(3, 19);
    }

    public int _3D6_2_Times()
    {
        var first = RandomProvider.GetSecureRandomByte(3, 19);
        var second = RandomProvider.GetSecureRandomByte(3, 19);
        return Math.Max(first, second);
    }

    public int Throw(DiceThrowAttribute? diceThrowAttribute, DiceThrowModifierAttribute? diceThrowModifierAttribute, SpecialTrainingAttribute? specialTrainingAttribute)
    {
        ArgumentNullException.ThrowIfNull(diceThrowAttribute);
        return Throw(diceThrowAttribute.DiceThrowType, diceThrowModifierAttribute?.Modifier ?? 0, specialTrainingAttribute != null);
    }

    public int Throw(ThrowType throwType, int modifier = 0, bool specialTraing = false)
    {
        var throwResult = throwType switch
        {
            ThrowType._1D2 => _1D2(),
            ThrowType._1D3 => _1D3(),
            ThrowType._1D5 => _1D5(),
            ThrowType._1D6 => _1D6(),
            ThrowType._1D6_Ranged => _1D6_RangedAttack(),
            ThrowType._4D6 => _4D6(),
            ThrowType._5D6 => _5D6(),
            ThrowType._7D6 => _7D6(),
            ThrowType._8D6 => _8D6(),
            ThrowType._10D6 => _10D6(),
            ThrowType._14D6 => _14D6(),
            ThrowType._15D6 => _15D6(),
            ThrowType._1D9 => _1D9(),
            ThrowType._1D10 => _1D10(),
            ThrowType._1D10_Ranged => _1D10_RangedAttack(),
            ThrowType._2D10 => _2D10(),
            ThrowType._2D10_Ranged => _2D10_RangedAttack(),
            ThrowType._3D10 => _3D10(),
            ThrowType._2D6 => _2D6(),
            ThrowType._2D6_Ranged => _2D6_RangedAttack(),
            ThrowType._3D6 => _3D6(),
            ThrowType._3D6_2_Times => _3D6_2_Times(),
            ThrowType._3D6_Ranged => _3D6_RangedAttack(),
            ThrowType._4D6_Ranged => _4D6_RangedAttack(),
            ThrowType._5D6_Ranged => _5D6_RangedAttack(),
            ThrowType._6D6_Ranged => _6D6_RangedAttack(),
            ThrowType._7D6_Ranged => _7D6_RangedAttack(),
            ThrowType._8D6_Ranged => _8D6_RangedAttack(),
            ThrowType._9D6_Ranged => _9D6_RangedAttack(),
            ThrowType._10D6_Ranged => _10D6_RangedAttack(),
            ThrowType._11D6_Ranged => _11D6_RangedAttack(),
            ThrowType._12D6_Ranged => _12D6_RangedAttack(),
            ThrowType._13D6_Ranged => _13D6_RangedAttack(),
            ThrowType._14D6_Ranged => _14D6_RangedAttack(),
            ThrowType._15D6_Ranged => _15D6_RangedAttack(),
            ThrowType._1D100 => _1D100(),
            ThrowType._3D100 => _3D100(),
            ThrowType._4D10 => _4D10(),
            ThrowType._10D10 => _10D10(),
            _ => throw new ArgumentOutOfRangeException(nameof(throwType))
        };
        var result = throwResult + modifier;
        return specialTraing ? SpecialTraining(result) : result;
    }

    private static int RangedAttack(int min, int max)
    {
        int result = 0, partialResult;
        do
        {
            partialResult = RandomProvider.GetSecureRandomInt(min, max);
            result += partialResult;
        }
        while (partialResult == (max - 1));
        return result;
    }

    private int SpecialTraining(int baseValue)
    {
        var special = _1D100();
        if (special == 1)
        {
            throw new Exception("The character died during special training.");
        }

        if (special < 21)
        {
            var worse = _1D6();
            return baseValue - worse;
        }

        if (special < 51)
        {
            return 17;
        }

        if (special < 76)
        {
            return baseValue;
        }

        if (special < 96)
        {
            return 19;
        }

        return 20;
    }

    public int _4D10()
    {
        return RandomProvider.GetSecureRandomByte(4, 41);
    }

    public int _10D10()
    {
        return RandomProvider.GetSecureRandomByte(10, 101);
    }

    public int _4D6()
    {
        return RandomProvider.GetSecureRandomByte(4, 25);
    }


    public int _5D6()
    {
        return RandomProvider.GetSecureRandomByte(5, 31);
    }

    public int _7D6()
    {
        return RandomProvider.GetSecureRandomByte(7, 43);
    }

    public int _8D6()
    {
        return RandomProvider.GetSecureRandomByte(8, 49);
    }

    public int _10D6()
    {
        return RandomProvider.GetSecureRandomByte(10, 61);
    }

    public int _14D6()
    {
        return RandomProvider.GetSecureRandomByte(14, 85);
    }

    public int _15D6()
    {
        return RandomProvider.GetSecureRandomByte(5, 91);
    }
}
