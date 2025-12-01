using M.A.G.U.S.Assistant.Database.Repositories;
using M.A.G.U.S.Interfaces;
using Mtf.LanguageService.Enums;

namespace M.A.G.U.S.Assistant.Services;

internal sealed class SettingsService(SettingsRepository repo) : ISettings
{
    private readonly SettingsRepository repo = repo;

    public bool AddFightValueOnFirstLevelForAllClass { get; private set; }
    public bool AddPainToleranceOnFirstLevelForAllClass { get; private set; }
    public bool AddQualificationPointsOnFirstLevelForAllClass { get; private set; }
    public bool AddManaPointsOnFirstLevelForAllClass { get; private set; }
    public bool AddPsiPointsOnFirstLevelForAllClass { get; private set; }
    public bool AutoDistributeCombatValues { get; private set; }
    public bool AutoDistributeQualificationPoints { get; private set; }
    public bool AutoIncreasePainTolerance { get; private set; }
    public bool AutoGenerateSkills { get; private set; }

    private const string KeyLanguage = "Setting_Language";

    private const string KeyFightValue = "Setting_FightValueFirstLevel";
    private const string KeyPainTolerance = "Setting_PainToleranceFirstLevel";
    private const string KeyQualification = "Setting_QualificationPointsFirstLevel";
    private const string KeyMana = "Setting_ManaPointsFirstLevel";
    private const string KeyPsi = "Setting_PsiPointsFirstLevel";

    private const string KeyCombatValue = "Setting_CombatValueDistribution";
    private const string KeyQualificationPoints = "Setting_QualificationPointsDistribution";
    private const string KeyPainToleranceIncrease = "Setting_PainToleranceIncrease";
    private const string KeySkills = "Setting_SkillGeneration";

    public async Task LoadAsync()
    {
        AddFightValueOnFirstLevelForAllClass = await repo.GetBoolSettingAsync(KeyFightValue, true).ConfigureAwait(false);
        AddPainToleranceOnFirstLevelForAllClass = await repo.GetBoolSettingAsync(KeyPainTolerance, true).ConfigureAwait(false);
        AddQualificationPointsOnFirstLevelForAllClass = await repo.GetBoolSettingAsync(KeyQualification, true).ConfigureAwait(false);
        AddManaPointsOnFirstLevelForAllClass = await repo.GetBoolSettingAsync(KeyMana, false).ConfigureAwait(false);
        AddPsiPointsOnFirstLevelForAllClass = await repo.GetBoolSettingAsync(KeyPsi, false).ConfigureAwait(false);

        AutoDistributeCombatValues = await repo.GetBoolSettingAsync(KeyCombatValue, false).ConfigureAwait(false);
        AutoDistributeQualificationPoints = await repo.GetBoolSettingAsync(KeyQualificationPoints, false).ConfigureAwait(false);
        AutoIncreasePainTolerance = await repo.GetBoolSettingAsync(KeyPainToleranceIncrease, false).ConfigureAwait(false);
        AutoGenerateSkills = await repo.GetBoolSettingAsync(KeySkills, false).ConfigureAwait(false);
    }

    public Task SaveAddFightValueAsync(bool value)
    {
        AddFightValueOnFirstLevelForAllClass = value;
        return repo.SaveBoolSettingAsync(KeyFightValue, value);
    }

    public Task SaveAddPainToleranceAsync(bool value)
    {
        AddPainToleranceOnFirstLevelForAllClass = value;
        return repo.SaveBoolSettingAsync(KeyPainTolerance, value);
    }

    public Task SaveAddQualificationAsync(bool value)
    {
        AddQualificationPointsOnFirstLevelForAllClass = value;
        return repo.SaveBoolSettingAsync(KeyQualification, value);
    }

    public Task SaveAddManaAsync(bool value)
    {
        AddManaPointsOnFirstLevelForAllClass = value;
        return repo.SaveBoolSettingAsync(KeyMana, value);
    }

    public Task SaveAddPsiAsync(bool value)
    {
        AddPsiPointsOnFirstLevelForAllClass = value;
        return repo.SaveBoolSettingAsync(KeyPsi, value);
    }

    public Task SaveAutoCombatValueDistributionAsync(bool value)
    {
        AutoDistributeCombatValues = value;
        return repo.SaveBoolSettingAsync(KeyCombatValue, value);
    }

    public Task SaveAutoQualificationPointsDistributionAsync(bool value)
    {
        AutoDistributeQualificationPoints = value;
        return repo.SaveBoolSettingAsync(KeyQualificationPoints, value);
    }

    public Task SaveAutoPainToleranceIncreaseAsync(bool value)
    {
        AutoIncreasePainTolerance = value;
        return repo.SaveBoolSettingAsync(KeyPainToleranceIncrease, value);
    }

    public Task SaveAutoGenerateSkillsAsync(bool value)
    {
        AutoGenerateSkills = value;
        return repo.SaveBoolSettingAsync(KeySkills, value);
    }

    public async Task<Language> GetCurrentLanguageAsync()
    {
        var langString = await repo.GetSettingAsync(KeyLanguage).ConfigureAwait(false);
        return Enum.TryParse<Language>(langString, out var savedLanguage) ? savedLanguage : Language.Hungarian;
    }

    public Task SaveDefaultLanguageAsync(Language language)
    {
        return repo.SaveSettingAsync(KeyLanguage, language.ToString());
    }
}