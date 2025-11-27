namespace M.A.G.U.S.Interfaces;

public interface ISettings
{
    bool AddFightValueOnFirstLevelForAllClass { get; }

    bool AddPainToleranceOnFirstLevelForAllClass { get; }

    bool AddQualificationPointsOnFirstLevelForAllClass { get; }

    bool AddManaPointsOnFirstLevelForAllClass { get; }

    bool AddPsiPointsOnFirstLevelForAllClass { get; }

    bool AutoDistributeCombatValues { get; }
    
    bool AutoDistributeQualificationPoints { get; }
    
    bool AutoIncreasePainTolerance { get; }
    
    bool AutoGenerateSkills { get; }
}
