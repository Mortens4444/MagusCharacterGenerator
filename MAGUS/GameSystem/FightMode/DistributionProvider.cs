using MAGUS.Interfaces;
using MAGUS.Races;

namespace MAGUS.GameSystem.FightMode;

public static class DistributionProvider
{
    public static (int AttackPercentage, int DefensePercentage, int AimPercentage) Get(IClass @class, IRace race)
    {
        if ((@class is IUseRangedWeapons) && (race is IUseRangedWeapons))
        {
            return (10, 10, 80);
        }
        else if ((@class is IUseRangedWeapons) || (race is IUseRangedWeapons))
        {
            return (25, 25, 50);
        }
        else if ((@class is IHateRangedWeapons) || (race is IHateRangedWeapons))
        {
            return (50, 50, 0);
        }
        return (35, 35, 30);
    }
}
