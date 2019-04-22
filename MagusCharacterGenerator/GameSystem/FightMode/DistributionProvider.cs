using MagusCharacterGenerator.Castes;
using MagusCharacterGenerator.Race;

namespace MagusCharacterGenerator.GameSystem.FightMode
{
    static class DistributionProvider
    {
        public static (byte AttackPercentage, byte DefensePercentage, byte AimingPercentage) Get(ICaste caste, IRace race)
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
}
