using Mtf.LanguageService.Enums;

namespace M.A.G.U.S.Assistant;

internal class Constants
{
    public const bool AddCombatValueModifierPointsOnFirstLevelForAllClass = true;
    public const bool AddPainTolerancePointsOnFirstLevelForAllClass = true;
    public const bool AddQualificationPointsOnFirstLevelForAllClass = true;
    public const bool AddManaPointsOnFirstLevelForAllClass = false;
    public const bool AddPsiPointsOnFirstLevelForAllClass = false;
    public const bool AutoDistributeCombatValues = false;
    public const bool AutoDistributeQualificationPoints = false;
    public const bool AutoIncreasePainTolerance = false;
    public const bool AutoIncreaseMana = false;
    public const bool AutoGenerateSkills = false;
    public const int MaxDiesCount = 1;
    public const bool UseRaceClassRestrictions = true;
    public const bool AssignmentTurnHistoryNewestOnTop = true;
    public const bool ShowRandomBeastWhenBestiaryPageOpened = true;

    public const Language DefaultLanguage = Language.Hungarian;
}
