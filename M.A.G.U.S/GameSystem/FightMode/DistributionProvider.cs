using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.GameSystem.FightMode;

public static class DistributionProvider
{
    public static (int AttackPercentage, int DefensePercentage, int AimingPercentage) Get(IClass @class, IRace race)
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
