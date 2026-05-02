using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;

namespace M.A.G.U.S.Services;

public sealed class HorseQualityResult
{
    public int Roll { get; init; }

    public HorseQuality Quality { get; init; }

    public int? DiesInDays { get; init; }

    public double SpeedMultiplier { get; init; } = 1d;

    public List<HorseBadHabit> BadHabits { get; init; } = [];

    public List<HorseSpecialAbility> SpecialAbilities { get; init; } = [];

    private static readonly DiceThrow diceThrow = new();

    public static HorseQualityResult RollHorseQuality(ThrowType rollMode = ThrowType._2D10)
    {
        var roll = diceThrow.Throw(rollMode);
        return roll switch
        {
            2 => new HorseQualityResult
            {
                Roll = roll,
                Quality = HorseQuality.BrokenDown,
                DiesInDays = diceThrow._1D6()
            },

            3 => new HorseQualityResult
            {
                Roll = roll,
                Quality = HorseQuality.Lame,
                SpeedMultiplier = 0.5d
            },

            4 => new HorseQualityResult
            {
                Roll = roll,
                Quality = HorseQuality.Weak
            },

            5 => new HorseQualityResult
            {
                Roll = roll,
                Quality = HorseQuality.IllMannered,
                BadHabits = RollBadHabits(3)
            },

            6 or 7 => new HorseQualityResult
            {
                Roll = roll,
                Quality = HorseQuality.Restless,
                BadHabits = RollBadHabits(2)
            },

            8 or 9 => new HorseQualityResult
            {
                Roll = roll,
                Quality = HorseQuality.Average,
                BadHabits = RollBadHabits(1)
            },

            >= 10 and <= 12 => new HorseQualityResult
            {
                Roll = roll,
                Quality = HorseQuality.Average
            },

            13 or 14 => new HorseQualityResult
            {
                Roll = roll,
                Quality = HorseQuality.Average,
                SpecialAbilities = RollSpecialAbilities(1)
            },

            15 or 16 => new HorseQualityResult
            {
                Roll = roll,
                Quality = HorseQuality.Tame,
                SpecialAbilities = RollSpecialAbilities(2)
            },

            17 => new HorseQualityResult
            {
                Roll = roll,
                Quality = HorseQuality.Attached,
                SpecialAbilities = RollSpecialAbilities(3)
            },

            18 => new HorseQualityResult
            {
                Roll = roll,
                Quality = HorseQuality.Special,
                SpecialAbilities = [HorseSpecialAbility.Loyal]
            },

            19 => new HorseQualityResult
            {
                Roll = roll,
                Quality = HorseQuality.FastSpecial,
                SpeedMultiplier = 1.2d
            },

            20 => new HorseQualityResult
            {
                Roll = roll,
                Quality = HorseQuality.Taltos
            },

            _ => throw new InvalidOperationException($"Invalid horse quality roll: {roll}.")
        };
    }

    private static List<HorseBadHabit> RollBadHabits(int count)
    {
        return RollUnique(() => (HorseBadHabit)diceThrow._1D10(), count);
    }

    private static List<HorseSpecialAbility> RollSpecialAbilities(int count)
    {
        return RollUnique(() => (HorseSpecialAbility)diceThrow._1D10(), count);
    }

    private static List<T> RollUnique<T>(Func<T> roll, int count)
        where T : struct, Enum
    {
        var result = new List<T>();

        while (result.Count < count)
        {
            var value = roll();
            if (!result.Contains(value))
            {
                result.Add(value);
            }
        }

        return result;
    }
}