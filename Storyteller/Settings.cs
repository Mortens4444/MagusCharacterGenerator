using M.A.G.U.S.Interfaces;

namespace Storyteller
{
    class Settings : ISettings
    {
        public bool AddCombatValueOnFirstLevelForAllClass => true;

        public bool AddPainToleranceOnFirstLevelForAllClass => true;

        public bool AddQualificationPointsOnFirstLevelForAllClass => true;

        public bool AddManaPointsOnFirstLevelForAllClass => true;

        public bool AddPsiPointsOnFirstLevelForAllClass => true;

        public bool AutoDistributeCombatValues => true;

        public bool AutoDistributeQualificationPoints => true;

        public bool AutoIncreasePainTolerance => true;

        public bool AutoGenerateSkills => true;

        public bool AssignmentTurnHistoryNewestOnTop => true;

        public bool AutoIncreaseManaPoints => true;

        public int MaxDiesCount => 1;

        public bool UseRaceClassRestrictions => true;
    }
}
