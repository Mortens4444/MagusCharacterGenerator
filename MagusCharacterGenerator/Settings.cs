using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Test
{
    class Settings : ISettings
    {
        public bool AddFightValueOnFirstLevelForAllClass => true;

        public bool AddPainToleranceOnFirstLevelForAllClass => true;

        public bool AddQualificationPointsOnFirstLevelForAllClass => true;

        public bool AddManaPointsOnFirstLevelForAllClass => true;

        public bool AddPsiPointsOnFirstLevelForAllClass => true;

        public bool AutoDistributeCombatValues => true;

        public bool AutoDistributeQualificationPoints => true;

        public bool AutoIncreasePainTolerance => true;

        public bool AutoGenerateSkills => true;
    }
}
