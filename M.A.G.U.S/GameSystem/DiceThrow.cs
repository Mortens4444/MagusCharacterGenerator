using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using Mtf.Extensions.Services;
using Range = M.A.G.U.S.Models.Range;

namespace M.A.G.U.S.GameSystem;

public class DiceThrow
{
    /// <summary>
    /// Alkalmazza a szerencse amullett logikáját: 
    /// Minimum esetén maximum, (max - 1) esetén szintén maximum jön vissza.
    /// </summary>
    private int ApplyLuck(int result, int min, int exclusiveMax, bool hasLuckAmulet)
    {
        if (!hasLuckAmulet) return result;

        int actualMax = exclusiveMax - 1;
        // Ha a dobott érték a minimum VAGY az eggyel a maximum alatti
        if (result == min || result == actualMax - 1)
        {
            return actualMax;
        }
        return result;
    }

    public int _1D2(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(1, 3), 1, 3, hasLuckAmulet);

    public int _1D3(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(1, 4), 1, 4, hasLuckAmulet);

    public int _1D3_RangedAttack(bool hasLuckAmulet = false) =>
        RangedAttack(1, 4, hasLuckAmulet);

    public int _1D5(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(1, 6), 1, 6, hasLuckAmulet);

    public int _1D5_RangedAttack(bool hasLuckAmulet = false) =>
        RangedAttack(1, 6, hasLuckAmulet);

    public int _1D6(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(1, 7), 1, 7, hasLuckAmulet);

    public int _1D6_RangedAttack(bool hasLuckAmulet = false) =>
        RangedAttack(1, 7, hasLuckAmulet);

    public int _2D6(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(2, 13), 2, 13, hasLuckAmulet);

    public int _2D6_RangedAttack(bool hasLuckAmulet = false) => RangedAttackND6(2, hasLuckAmulet);

    public int _3D6_RangedAttack(bool hasLuckAmulet = false) => RangedAttackND6(3, hasLuckAmulet);
    public int _4D6_RangedAttack(bool hasLuckAmulet = false) => RangedAttackND6(4, hasLuckAmulet);
    public int _5D6_RangedAttack(bool hasLuckAmulet = false) => RangedAttackND6(5, hasLuckAmulet);
    public int _6D6_RangedAttack(bool hasLuckAmulet = false) => RangedAttackND6(6, hasLuckAmulet);
    public int _7D6_RangedAttack(bool hasLuckAmulet = false) => RangedAttackND6(7, hasLuckAmulet);
    public int _8D6_RangedAttack(bool hasLuckAmulet = false) => RangedAttackND6(8, hasLuckAmulet);
    public int _9D6_RangedAttack(bool hasLuckAmulet = false) => RangedAttackND6(9, hasLuckAmulet);
    public int _10D6_RangedAttack(bool hasLuckAmulet = false) => RangedAttackND6(10, hasLuckAmulet);
    public int _11D6_RangedAttack(bool hasLuckAmulet = false) => RangedAttackND6(11, hasLuckAmulet);
    public int _12D6_RangedAttack(bool hasLuckAmulet = false) => RangedAttackND6(12, hasLuckAmulet);
    public int _13D6_RangedAttack(bool hasLuckAmulet = false) => RangedAttackND6(13, hasLuckAmulet);
    public int _14D6_RangedAttack(bool hasLuckAmulet = false) => RangedAttackND6(14, hasLuckAmulet);
    public int _15D6_RangedAttack(bool hasLuckAmulet = false) => RangedAttackND6(15, hasLuckAmulet);

    public int RangedAttackND6(int count, bool hasLuckAmulet = false)
    {
        var total = 0;
        for (var i = 0; i < count; i++)
        {
            total += RangedAttack(1, 7, hasLuckAmulet);
        }
        return total;
    }

    public int _1D6_Plus_10(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(11, 17), 11, 17, hasLuckAmulet);

    public int _1D6_Plus_12(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(13, 19), 13, 19, hasLuckAmulet);

    public int _1D6_Plus_12_Plus_SpecialTraining(bool hasLuckAmulet = false)
    {
        var baseValue = _1D6_Plus_12(hasLuckAmulet);
        return SpecialTraining(baseValue, hasLuckAmulet);
    }

    public int _1D6_Plus_14(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(15, 21), 15, 21, hasLuckAmulet);

    public int _1D1(bool hasLuckAmulet = false)
    {
        // 1D1 speciális: ha 1D6-tal 6-ost dobunk. A szerencse itt az 1D6-ra hat.
        if (_1D6(hasLuckAmulet) == 6)
        {
            return 1;
        }
        return 0;
    }

    public int _1D9(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(1, 10), 1, 10, hasLuckAmulet);

    public int _1D10(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(1, 11), 1, 11, hasLuckAmulet);

    public int _1D10_RangedAttack(bool hasLuckAmulet = false) =>
        RangedAttack(1, 11, hasLuckAmulet);

    public int _2D10(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(2, 21), 2, 21, hasLuckAmulet);

    public int _2D10_RangedAttack(bool hasLuckAmulet = false) =>
        RangedAttack(1, 11, hasLuckAmulet) + RangedAttack(1, 11, hasLuckAmulet);

    public int _3D10(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(3, 31), 3, 31, hasLuckAmulet);

    public int _1D10_Plus_8(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(9, 19), 9, 19, hasLuckAmulet);

    public int _1D10_Plus_8_2_Times(bool hasLuckAmulet = false)
    {
        var first = _1D10_Plus_8(hasLuckAmulet);
        var second = _1D10_Plus_8(hasLuckAmulet);
        return Math.Max(first, second);
    }

    public int _1D10_Plus_8_Plus_SpecialTraining(bool hasLuckAmulet = false)
    {
        var baseValue = _1D10_Plus_8(hasLuckAmulet);
        return SpecialTraining(baseValue, hasLuckAmulet);
    }

    public int _1D10_Plus_10(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(11, 21), 11, 21, hasLuckAmulet);

    public int _1D100(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(1, 101), 1, 101, hasLuckAmulet);

    public int _2D100(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(1, 201), 1, 201, hasLuckAmulet);

    public int _3D100(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomInt(1, 301), 1, 301, hasLuckAmulet);

    public int _2D6_Plus_3(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(5, 16), 5, 16, hasLuckAmulet);

    public int _2D6_Plus_6(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(8, 19), 8, 19, hasLuckAmulet);

    public int _2D6_Plus_6_Plus_SpecialTraining(bool hasLuckAmulet = false)
    {
        var baseValue = _2D6_Plus_6(hasLuckAmulet);
        return SpecialTraining(baseValue, hasLuckAmulet);
    }

    public int _3D6(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(3, 19), 3, 19, hasLuckAmulet);

    public int _3D6_2_Times(bool hasLuckAmulet = false)
    {
        var first = _3D6(hasLuckAmulet);
        var second = _3D6(hasLuckAmulet);
        return Math.Max(first, second);
    }

    public int _1D10_2_Times(bool hasLuckAmulet = false)
    {
        var first = _1D10(hasLuckAmulet);
        var second = _1D10(hasLuckAmulet);
        return Math.Max(first, second);
    }

    public int Throw(DiceThrowAttribute? diceThrowAttribute, DiceThrowModifierAttribute? diceThrowModifierAttribute, SpecialTrainingAttribute? specialTrainingAttribute, bool hasLuckAmulet = false)
    {
        ArgumentNullException.ThrowIfNull(diceThrowAttribute);
        return Throw(diceThrowAttribute.DiceThrowType, diceThrowModifierAttribute?.Modifier ?? 0, specialTrainingAttribute != null, hasLuckAmulet);
    }

    public int Throw(ThrowType throwType, int modifier = 0, bool specialTraing = false, bool hasLuckAmulet = false)
    {
        var throwResult = throwType switch
        {
            ThrowType._1D2 => _1D2(hasLuckAmulet),
            ThrowType._1D3 => _1D3(hasLuckAmulet),
            ThrowType._1D5 => _1D5(hasLuckAmulet),
            ThrowType._1D6 => _1D6(hasLuckAmulet),
            ThrowType._2D6 => _2D6(hasLuckAmulet),
            ThrowType._3D6 => _3D6(hasLuckAmulet),
            ThrowType._3D6_2_Times => _3D6_2_Times(hasLuckAmulet),
            ThrowType._4D6 => _4D6(hasLuckAmulet),
            ThrowType._5D6 => _5D6(hasLuckAmulet),
            ThrowType._6D6 => _6D6(hasLuckAmulet),
            ThrowType._7D6 => _7D6(hasLuckAmulet),
            ThrowType._8D6 => _8D6(hasLuckAmulet),
            ThrowType._9D6 => _9D6(hasLuckAmulet),
            ThrowType._10D6 => _10D6(hasLuckAmulet),
            ThrowType._11D6 => _11D6(hasLuckAmulet),
            ThrowType._12D6 => _12D6(hasLuckAmulet),
            ThrowType._13D6 => _13D6(hasLuckAmulet),
            ThrowType._14D6 => _14D6(hasLuckAmulet),
            ThrowType._15D6 => _15D6(hasLuckAmulet),
            ThrowType._1D9 => _1D9(hasLuckAmulet),
            ThrowType._1D10 => _1D10(hasLuckAmulet),
            ThrowType._1D10_2_Times => _1D10_2_Times(hasLuckAmulet),
            ThrowType._2D10 => _2D10(hasLuckAmulet),
            ThrowType._3D10 => _3D10(hasLuckAmulet),
            ThrowType._4D10 => _4D10(hasLuckAmulet),
            ThrowType._5D10 => _5D10(hasLuckAmulet),
            ThrowType._6D10 => _6D10(hasLuckAmulet),
            ThrowType._10D10 => _10D10(hasLuckAmulet),
            ThrowType._1D100 => _1D100(hasLuckAmulet),
            ThrowType._3D100 => _3D100(hasLuckAmulet),
            ThrowType._1D6_Ranged => _1D6_RangedAttack(hasLuckAmulet),
            ThrowType._2D6_Ranged => _2D6_RangedAttack(hasLuckAmulet),
            ThrowType._1D10_Ranged => _1D10_RangedAttack(hasLuckAmulet),
            ThrowType._2D10_Ranged => _2D10_RangedAttack(hasLuckAmulet),
            ThrowType._3D6_Ranged => _3D6_RangedAttack(hasLuckAmulet),
            ThrowType._4D6_Ranged => _4D6_RangedAttack(hasLuckAmulet),
            ThrowType._5D6_Ranged => _5D6_RangedAttack(hasLuckAmulet),
            ThrowType._6D6_Ranged => _6D6_RangedAttack(hasLuckAmulet),
            ThrowType._7D6_Ranged => _7D6_RangedAttack(hasLuckAmulet),
            ThrowType._8D6_Ranged => _8D6_RangedAttack(hasLuckAmulet),
            ThrowType._9D6_Ranged => _9D6_RangedAttack(hasLuckAmulet),
            ThrowType._10D6_Ranged => _10D6_RangedAttack(hasLuckAmulet),
            ThrowType._11D6_Ranged => _11D6_RangedAttack(hasLuckAmulet),
            ThrowType._12D6_Ranged => _12D6_RangedAttack(hasLuckAmulet),
            ThrowType._13D6_Ranged => _13D6_RangedAttack(hasLuckAmulet),
            ThrowType._14D6_Ranged => _14D6_RangedAttack(hasLuckAmulet),
            ThrowType._15D6_Ranged => _15D6_RangedAttack(hasLuckAmulet),
            _ => throw new ArgumentOutOfRangeException(nameof(throwType))
        };
        var result = throwResult + modifier;
        return specialTraing ? SpecialTraining(result, hasLuckAmulet) : result;
    }

    public Range GetRange(ThrowType throwType, int modifier = 0, bool specialTraing = false)
    {
        // A Range fix matematikai határokat jelöl, a szerencse amullett csak a valószínűséget/eredményt módosítja, 
        // a kockák elméleti maximumát nem lépi túl, így ez a rész változatlan maradhat.
        var result = throwType switch
        {
            ThrowType._1D2 => new Range { Max = 2 },
            ThrowType._1D3 => new Range { Max = 3 },
            ThrowType._1D5 => new Range { Max = 5 },
            ThrowType._1D6 => new Range { Max = 6 },
            ThrowType._2D6 => new Range { Min = 2, Max = 12 },
            ThrowType._3D6 => new Range { Min = 3, Max = 18 },
            ThrowType._3D6_2_Times => new Range { Min = 3, Max = 18 },
            ThrowType._4D6 => new Range { Min = 4, Max = 24 },
            ThrowType._5D6 => new Range { Min = 5, Max = 30 },
            ThrowType._6D6 => new Range { Min = 6, Max = 36 },
            ThrowType._7D6 => new Range { Min = 7, Max = 42 },
            ThrowType._8D6 => new Range { Min = 8, Max = 48 },
            ThrowType._9D6 => new Range { Min = 9, Max = 54 },
            ThrowType._10D6 => new Range { Min = 10, Max = 60 },
            ThrowType._11D6 => new Range { Min = 11, Max = 66 },
            ThrowType._12D6 => new Range { Min = 12, Max = 72 },
            ThrowType._13D6 => new Range { Min = 13, Max = 78 },
            ThrowType._14D6 => new Range { Min = 14, Max = 84 },
            ThrowType._15D6 => new Range { Min = 15, Max = 90 },
            ThrowType._1D9 => new Range { Max = 9 },
            ThrowType._1D10 => new Range { Max = 10 },
            ThrowType._1D10_2_Times => new Range { Max = 10 },
            ThrowType._2D10 => new Range { Min = 2, Max = 20 },
            ThrowType._3D10 => new Range { Min = 3, Max = 30 },
            ThrowType._4D10 => new Range { Min = 4, Max = 40 },
            ThrowType._5D10 => new Range { Min = 5, Max = 50 },
            ThrowType._6D10 => new Range { Min = 6, Max = 60 },
            ThrowType._10D10 => new Range { Min = 10, Max = 100 },
            ThrowType._1D100 => new Range { Max = 100 },
            ThrowType._3D100 => new Range { Min = 3, Max = 300 },
            ThrowType._1D6_Ranged => new Range { Min = 1, Max = 6 },
            ThrowType._1D10_Ranged => new Range { Min = 1, Max = 10 },
            ThrowType._2D10_Ranged => new Range { Min = 2, Max = 20 },
            ThrowType._2D6_Ranged => new Range { Min = 2, Max = 12 },
            ThrowType._3D6_Ranged => new Range { Min = 3, Max = 18 },
            ThrowType._4D6_Ranged => new Range { Min = 4, Max = 24 },
            ThrowType._5D6_Ranged => new Range { Min = 5, Max = 30 },
            ThrowType._6D6_Ranged => new Range { Min = 6, Max = 36 },
            ThrowType._7D6_Ranged => new Range { Min = 7, Max = 42 },
            ThrowType._8D6_Ranged => new Range { Min = 8, Max = 48 },
            ThrowType._9D6_Ranged => new Range { Min = 9, Max = 54 },
            ThrowType._10D6_Ranged => new Range { Min = 10, Max = 60 },
            ThrowType._11D6_Ranged => new Range { Min = 11, Max = 66 },
            ThrowType._12D6_Ranged => new Range { Min = 12, Max = 72 },
            ThrowType._13D6_Ranged => new Range { Min = 13, Max = 78 },
            ThrowType._14D6_Ranged => new Range { Min = 14, Max = 84 },
            ThrowType._15D6_Ranged => new Range { Min = 15, Max = 90 },
            _ => throw new ArgumentOutOfRangeException(nameof(throwType))
        };
        result.Min += modifier;
        result.Max += modifier;
        if (specialTraing)
        {
            result.Min -= 6;
        }
        return result;
    }

    private int RangedAttack(int min, int max, bool hasLuckAmulet)
    {
        int result = 0, partialResult;
        do
        {
            partialResult = RandomProvider.GetSecureRandomInt(min, max);
            // Alkalmazzuk a szerencsét a részeredményre
            partialResult = ApplyLuck(partialResult, min, max, hasLuckAmulet);
            result += partialResult;
        }
        // Az újradobás feltétele (M.A.G.U.S.-ban a max dobásnál adódik hozzá az új dobás)
        while (partialResult == (max - 1));
        return result;
    }

    private int SpecialTraining(int baseValue, bool hasLuckAmulet)
    {
        // Itt az 1D100 dobásra hat a szerencse: a halál (1) helyett max (100) lesz.
        var special = _1D100(hasLuckAmulet);
        if (special == 1)
        {
            throw new Exception("The character died during special training.");
        }

        if (special < 21)
        {
            var worse = _1D6(hasLuckAmulet);
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

    public int _4D10(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(4, 41), 4, 41, hasLuckAmulet);

    public int _5D10(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(5, 51), 5, 51, hasLuckAmulet);

    public int _6D10(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(6, 61), 6, 61, hasLuckAmulet);

    public int _10D10(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(10, 101), 10, 101, hasLuckAmulet);

    public int _4D6(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(4, 25), 4, 25, hasLuckAmulet);

    public int _5D6(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(5, 31), 5, 31, hasLuckAmulet);

    public int _6D6(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(6, 37), 6, 37, hasLuckAmulet);

    public int _7D6(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(7, 43), 7, 43, hasLuckAmulet);

    public int _8D6(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(8, 49), 8, 49, hasLuckAmulet);

    public int _9D6(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(9, 55), 9, 55, hasLuckAmulet);

    public int _10D6(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(10, 61), 10, 61, hasLuckAmulet);

    public int _11D6(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(11, 67), 11, 67, hasLuckAmulet);

    public int _12D6(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(12, 73), 12, 73, hasLuckAmulet);

    public int _13D6(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(13, 79), 13, 79, hasLuckAmulet);

    public int _14D6(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(14, 85), 14, 85, hasLuckAmulet);

    public int _15D6(bool hasLuckAmulet = false) =>
        ApplyLuck(RandomProvider.GetSecureRandomByte(15, 91), 15, 91, hasLuckAmulet);
}