using Mtf.Extensions.Services;

namespace M.A.G.U.S.GameSystem;

public class DiceThrow
{
    public sbyte _1K2()
    {
        return (sbyte)RandomProvider.GetSecureRandomByte(1, 2);
    }

    public sbyte _1K3()
    {
        return (sbyte)RandomProvider.GetSecureRandomByte(1, 3);
    }

    public int _1K3_RangedAttack()
    {
        return RangedAttack(1, 3);
    }

    public sbyte _1K5()
    {
        return (sbyte)RandomProvider.GetSecureRandomByte(1, 5);
    }

    public int _1K5_RangedAttack()
    {
        return RangedAttack(1, 5);
    }

    public sbyte _1K6()
    {
        return (sbyte)RandomProvider.GetSecureRandomByte(1, 6);
    }

    public int _1K6_RangedAttack()
    {
        return RangedAttack(1, 6);
    }

    public sbyte _2K6()
    {
        return (sbyte)RandomProvider.GetSecureRandomByte(2, 12);
    }

    public int _2K6_RangedAttack()
    {
        return RangedAttack(1, 6) + RangedAttack(1, 6);
    }

    public sbyte _1K6_Plus_12()
    {
        return (sbyte)RandomProvider.GetSecureRandomByte(13, 18);
    }

    public sbyte _1K6_Plus_12_Plus_SpecialTraining()
    {
        var baseValue = (sbyte)RandomProvider.GetSecureRandomByte(13, 18);
        return SpecialTraining(baseValue);
    }

    public sbyte _1K6_Plus_14()
    {
        return (sbyte)RandomProvider.GetSecureRandomByte(15, 20);
    }

    public sbyte _1K9()
    {
        return (sbyte)RandomProvider.GetSecureRandomByte(1, 9);
    }

    public sbyte _1K10()
    {
        return (sbyte)RandomProvider.GetSecureRandomByte(1, 10);
    }

    public int _1K10_RangedAttack()
    {
        return RangedAttack(1, 10);
    }

    public sbyte _2K10()
    {
        return (sbyte)RandomProvider.GetSecureRandomByte(2, 20);
    }

    public int _2K10_RangedAttack()
    {
        return RangedAttack(1, 10) + RangedAttack(1, 10);
    }

    public sbyte _3K10()
    {
        return (sbyte)RandomProvider.GetSecureRandomByte(3, 30);
    }

    public sbyte _1K10_Plus_8()
    {
        return (sbyte)RandomProvider.GetSecureRandomByte(9, 18);
    }

    public sbyte _1K10_Plus_8_2_Times()
    {
        var first = RandomProvider.GetSecureRandomByte(9, 18);
        var second = RandomProvider.GetSecureRandomByte(9, 18);
        return (sbyte)Math.Max(first, second);
    }

    public sbyte _1K10_Plus_8_Plus_SpecialTraining()
    {
        var baseValue = (sbyte)RandomProvider.GetSecureRandomByte(9, 18);
        return SpecialTraining(baseValue);
    }

    public sbyte _1K10_Plus_10()
    {
        return (sbyte)RandomProvider.GetSecureRandomByte(11, 20);
    }

	public sbyte _1K100()
	{
		return (sbyte)RandomProvider.GetSecureRandomByte(1, 100);
	}

	public byte _2K100()
	{
		return RandomProvider.GetSecureRandomByte(1, 200);
	}

	public short _3K100()
	{
		return RandomProvider.GetSecureRandomShort(1, 300);
	}

	public sbyte _2K6_Plus_3()
	{
		return (sbyte)RandomProvider.GetSecureRandomByte(5, 15);
	}

	public sbyte _2K6_Plus_6()
    {
        return (sbyte)RandomProvider.GetSecureRandomByte(8, 18);
    }

    public sbyte _2K6_Plus_6_Plus_SpecialTraining()
    {
        var baseValue = (sbyte)RandomProvider.GetSecureRandomByte(8, 18);
        return SpecialTraining(baseValue);
    }

    public sbyte _3K6()
    {
        return (sbyte)RandomProvider.GetSecureRandomByte(3, 18);
    }

    public sbyte _3K6_2_Times()
    {
        var first = (sbyte)RandomProvider.GetSecureRandomByte(3, 18);
        var second = (sbyte)RandomProvider.GetSecureRandomByte(3, 18);
        return Math.Max(first, second);
    }

    private static int RangedAttack(int min, int max)
    {
        int result = 0, partialResult;
        do
        {
            partialResult = RandomProvider.GetSecureRandomInt(min, max);
            result += partialResult;
        }
        while (partialResult == max);
        return result;
    }

    private sbyte SpecialTraining(sbyte baseValue)
    {
        var special = _1K100();
        if (special == 1)
        {
            throw new Exception("The character died during special training.");
        }

        if (special < 21)
        {
            var worse = _1K6();
            return (sbyte)(baseValue - worse);
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
}
