using Mtf.Extensions.Services;

namespace M.A.G.U.S.GameSystem;

public class DiceThrow
{
    public short _1K2()
    {
        return RandomProvider.GetSecureRandomShort(1, 2);
    }

    public short _1K3()
    {
        return RandomProvider.GetSecureRandomShort(1, 3);
    }

    public short _1K3_RangedAttack()
    {
        return RangedAttack(1, 3);
    }

    public short _1K5()
    {
        return RandomProvider.GetSecureRandomShort(1, 5);
    }

    public short _1K5_RangedAttack()
    {
        return RangedAttack(1, 5);
    }

    public short _1K6()
    {
        return RandomProvider.GetSecureRandomShort(1, 6);
    }

    public short _1K6_RangedAttack()
    {
        return RangedAttack(1, 6);
    }

    public short _2K6()
    {
        return RandomProvider.GetSecureRandomShort(2, 12);
    }

    public short _2K6_RangedAttack()
    {
        return (short)(RangedAttack(1, 6) + RangedAttack(1, 6));
    }

    public short _1K6_Plus_12()
    {
        return RandomProvider.GetSecureRandomShort(13, 18);
    }

    public short _1K6_Plus_12_Plus_SpecialTraining()
    {
        var baseValue = RandomProvider.GetSecureRandomShort(13, 18);
        return SpecialTraining(baseValue);
    }

    public short _1K6_Plus_14()
    {
        return RandomProvider.GetSecureRandomShort(15, 20);
    }

    public short _1K10()
    {
        return RandomProvider.GetSecureRandomShort(1, 10);
    }

    public short _1K10_RangedAttack()
    {
        return RangedAttack(1, 10);
    }

    public short _2K10()
    {
        return RandomProvider.GetSecureRandomShort(2, 20);
    }

    public short _3K10()
    {
        return RandomProvider.GetSecureRandomShort(3, 30);
    }

    public short _2K10_RangedAttack()
    {
        return (short)(RangedAttack(1, 10) + RangedAttack(1, 10));
    }

    public short _1K10_Plus_8()
    {
        return RandomProvider.GetSecureRandomShort(9, 18);
    }

    public short _1K10_Plus_8_2_Times()
    {
        var first = RandomProvider.GetSecureRandomShort(9, 18);
        var second = RandomProvider.GetSecureRandomShort(9, 18);
        return Math.Max(first, second);
    }

    public short _1K10_Plus_8_Plus_SpecialTraining()
    {
        var baseValue = RandomProvider.GetSecureRandomShort(9, 18);
        return SpecialTraining(baseValue);
    }

    public short _1K10_Plus_10()
    {
        return RandomProvider.GetSecureRandomShort(11, 20);
    }

		public short _1K100()
		{
			return RandomProvider.GetSecureRandomShort(1, 100);
		}

		public short _2K100()
		{
			return RandomProvider.GetSecureRandomShort(1, 200);
		}

		public short _3K100()
		{
			return RandomProvider.GetSecureRandomShort(1, 300);
		}

		public short _2K6_Plus_3()
		{
			return RandomProvider.GetSecureRandomShort(5, 15);
		}

		public short _2K6_Plus_6()
    {
        return RandomProvider.GetSecureRandomShort(8, 18);
    }

    public short _2K6_Plus_6_Plus_SpecialTraining()
    {
        var baseValue = RandomProvider.GetSecureRandomShort(8, 18);
        return SpecialTraining(baseValue);
    }

    public short _3K6()
    {
        return RandomProvider.GetSecureRandomShort(3, 18);
    }

    public short _3K6_2_Times()
    {
        var first = RandomProvider.GetSecureRandomShort(3, 18);
        var second = RandomProvider.GetSecureRandomShort(3, 18);
        return Math.Max(first, second);
    }

    private short RangedAttack(short min, short max)
    {
        short result = 0, partialResult;
        do
        {
            partialResult = RandomProvider.GetSecureRandomShort(min, max);
            result += partialResult;
        }
        while (partialResult == max);
        return result;
    }

    private short SpecialTraining(short baseValue)
    {
        var special = _1K100();
        if (special == -1)
        {
            throw new Exception("The character died on the special training.");
        }

        if (special < 21)
        {
            var worse = _1K6();
            return (short)(baseValue - worse);
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
