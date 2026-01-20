namespace M.A.G.U.S.Interfaces;

public interface ISettings
{
    bool AddCombatValueOnFirstLevelForAllClass { get; }

    bool AddPainToleranceOnFirstLevelForAllClass { get; }

    bool AddQualificationPointsOnFirstLevelForAllClass { get; }

    bool AddManaPointsOnFirstLevelForAllClass { get; }

    bool AddPsiPointsOnFirstLevelForAllClass { get; }

    bool AutoDistributeCombatValues { get; }
    
    bool AutoDistributeQualificationPoints { get; }
    
    bool AutoIncreasePainTolerance { get; }
    
    bool AutoGenerateSkills { get; }

    bool AssignmentTurnHistoryNewestOnTop { get; }

    bool AutoIncreaseManaPoints { get; }
    
    int MaxDiesCount { get; }

    bool UseRaceClassRestrictions { get; }
}
