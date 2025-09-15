using M.A.G.U.S.Classes;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.GameSystem.FightMode;

public static class DistributionProvider
{
    public static (byte AttackPercentage, byte DefensePercentage, byte AimingPercentage) Get(IClass caste, IRace race)
    {
        if ((caste is IUseRangedWeapons) || (race is IUseRangedWeapons))
        {
            return (25, 25, 50);
        }
        else if ((caste is IHateRangedWeapons) || (race is IHateRangedWeapons))
        {
            return (50, 50, 0);
        }
        return (35, 35, 30);
    }
}
