using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Test
{
    class Settings(bool addPsiPointOnFirstLevel) : ISettings
    {
        private readonly bool addPsiPointOnFirstLevel = addPsiPointOnFirstLevel;

        public bool AddCombatValueOnFirstLevelForAllClass => true;

        public bool AddPainToleranceOnFirstLevelForAllClass => true;

        public bool AddQualificationPointsOnFirstLevelForAllClass => true;

        public bool AddManaPointsOnFirstLevelForAllClass => true;

        public bool AddPsiPointsOnFirstLevelForAllClass => addPsiPointOnFirstLevel;

        public bool AutoDistributeCombatValues => true;

        public bool AutoDistributeQualificationPoints => true;

        public bool AutoIncreasePainTolerance => true;

        public bool AutoGenerateSkills => true;
    }
}
