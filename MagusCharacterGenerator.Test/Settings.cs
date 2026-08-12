using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.Test
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

        public bool AssignmentTurnHistoryNewestOnTop => true;

        public bool AutoIncreaseManaPoints => true;

        public int MaxDiesCount => 1;

        public bool UseRaceClassRestrictions => true;

        public bool ShowRandomBeastWhenBestiaryPageOpened => true;

        public CombatSimulatorMode CombatSimulatorMode => CombatSimulatorMode.SemiAuto;
    }
}
