using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Test
{
    class Settings : ISettings
    {
        private readonly bool addPsiPointOnFirstLevel;

        public Settings(bool addPsiPointOnFirstLevel)
        {
            this.addPsiPointOnFirstLevel = addPsiPointOnFirstLevel;
        }

        public bool AddFightValueOnFirstLevelForAllClass => true;

        public bool AddPainToleranceOnFirstLevelForAllClass => true;

        public bool AddQualificationPointsOnFirstLevelForAllClass => true;

        public bool AddManaPointsOnFirstLevelForAllClass => true;

        public bool AddPsiPointsOnFirstLevelForAllClass => addPsiPointOnFirstLevel;
    }
}
