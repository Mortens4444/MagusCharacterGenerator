using M.A.G.U.S.Assistant.Database.Repositories;
using M.A.G.U.S.Interfaces;
using Mtf.LanguageService.Enums;

namespace M.A.G.U.S.Assistant.Services;

internal sealed class SettingsService : ISettings
{
    private readonly SettingsRepository settingsRepository;

    public bool AddCombatValueOnFirstLevelForAllClass { get; private set; }
    public bool AddPainToleranceOnFirstLevelForAllClass { get; private set; }
    public bool AddQualificationPointsOnFirstLevelForAllClass { get; private set; }
    public bool AddManaPointsOnFirstLevelForAllClass { get; private set; }
    public bool AddPsiPointsOnFirstLevelForAllClass { get; private set; }
    public bool AutoDistributeCombatValues { get; private set; }
    public bool AutoDistributeQualificationPoints { get; private set; }
    public bool AutoIncreasePainTolerance { get; private set; }
    public bool AutoGenerateSkills { get; private set; }

    private const string KeyLanguage = "Setting_Language";

    private const string KeyAddCombatValueModifierPointsOnFirstLevel = "Setting_AddCombatValueModifierPointsOnFirstLevel";
    private const string KeyAddPainTolerancePointsOnFirstLevel = "Setting_AddPainTolerancePointsOnFirstLevel";
    private const string KeyAddQualificationPointsOnFirstLevel = "Setting_AddQualificationPointsOnFirstLevel";
    private const string KeyAddManaPointsOnFirstLevel = "Setting_AddManaPointsOnFirstLevel";
    private const string KeyAddPsiPointsOnFirstLevel = "Setting_AddPsiPointsOnFirstLevel";

    private const string KeyAutoCombatValueDistribution = "Setting_AutoCombatValueDistribution";
    private const string KeyAutoQualificationPointsDistribution = "Setting_AutoQualificationPointsDistribution";
    private const string KeyAutoPainToleranceIncrease = "Setting_AutoPainToleranceIncrease";
    private const string KeyAutoSkillGeneration = "Setting_AutoSkillGeneration";

    public SettingsService(SettingsRepository settingsRepository)
    {
        this.settingsRepository = settingsRepository;
        LoadAsync().GetAwaiter().GetResult();
    }

    private async Task LoadAsync()
    {
        AddCombatValueOnFirstLevelForAllClass = await settingsRepository.GetBoolSettingAsync(KeyAddCombatValueModifierPointsOnFirstLevel, Constants.AddCombatValueModifierPointsOnFirstLevelForAllClass).ConfigureAwait(false);
        AddPainToleranceOnFirstLevelForAllClass = await settingsRepository.GetBoolSettingAsync(KeyAddPainTolerancePointsOnFirstLevel, Constants.AddPainTolerancePointsOnFirstLevelForAllClass).ConfigureAwait(false);
        AddQualificationPointsOnFirstLevelForAllClass = await settingsRepository.GetBoolSettingAsync(KeyAddQualificationPointsOnFirstLevel, Constants.AddQualificationPointsOnFirstLevelForAllClass).ConfigureAwait(false);
        AddManaPointsOnFirstLevelForAllClass = await settingsRepository.GetBoolSettingAsync(KeyAddManaPointsOnFirstLevel, Constants.AddManaPointsOnFirstLevelForAllClass).ConfigureAwait(false);
        AddPsiPointsOnFirstLevelForAllClass = await settingsRepository.GetBoolSettingAsync(KeyAddPsiPointsOnFirstLevel, Constants.AddPsiPointsOnFirstLevelForAllClass).ConfigureAwait(false);

        AutoDistributeCombatValues = await settingsRepository.GetBoolSettingAsync(KeyAutoCombatValueDistribution, Constants.AutoDistributeCombatValues).ConfigureAwait(false);
        AutoDistributeQualificationPoints = await settingsRepository.GetBoolSettingAsync(KeyAutoQualificationPointsDistribution, Constants.AutoDistributeQualificationPoints).ConfigureAwait(false);
        AutoIncreasePainTolerance = await settingsRepository.GetBoolSettingAsync(KeyAutoPainToleranceIncrease, Constants.AutoIncreasePainTolerance).ConfigureAwait(false);
        AutoGenerateSkills = await settingsRepository.GetBoolSettingAsync(KeyAutoSkillGeneration, Constants.AutoGenerateSkills).ConfigureAwait(false);
    }

    public Task SaveAddCombatValueAsync(bool value)
    {
        AddCombatValueOnFirstLevelForAllClass = value;
        return settingsRepository.SaveBoolSettingAsync(KeyAddCombatValueModifierPointsOnFirstLevel, value);
    }

    public Task SaveAddPainToleranceAsync(bool value)
    {
        AddPainToleranceOnFirstLevelForAllClass = value;
        return settingsRepository.SaveBoolSettingAsync(KeyAddPainTolerancePointsOnFirstLevel, value);
    }

    public Task SaveAddQualificationAsync(bool value)
    {
        AddQualificationPointsOnFirstLevelForAllClass = value;
        return settingsRepository.SaveBoolSettingAsync(KeyAddQualificationPointsOnFirstLevel, value);
    }

    public Task SaveAddManaAsync(bool value)
    {
        AddManaPointsOnFirstLevelForAllClass = value;
        return settingsRepository.SaveBoolSettingAsync(KeyAddManaPointsOnFirstLevel, value);
    }

    public Task SaveAddPsiAsync(bool value)
    {
        AddPsiPointsOnFirstLevelForAllClass = value;
        return settingsRepository.SaveBoolSettingAsync(KeyAddPsiPointsOnFirstLevel, value);
    }

    public Task SaveAutoCombatValueDistributionAsync(bool value)
    {
        AutoDistributeCombatValues = value;
        return settingsRepository.SaveBoolSettingAsync(KeyAutoCombatValueDistribution, value);
    }

    public Task SaveAutoQualificationPointsDistributionAsync(bool value)
    {
        AutoDistributeQualificationPoints = value;
        return settingsRepository.SaveBoolSettingAsync(KeyAutoQualificationPointsDistribution, value);
    }

    public Task SaveAutoPainToleranceIncreaseAsync(bool value)
    {
        AutoIncreasePainTolerance = value;
        return settingsRepository.SaveBoolSettingAsync(KeyAutoPainToleranceIncrease, value);
    }

    public Task SaveAutoGenerateSkillsAsync(bool value)
    {
        AutoGenerateSkills = value;
        return settingsRepository.SaveBoolSettingAsync(KeyAutoSkillGeneration, value);
    }

    public async Task<Language> GetCurrentLanguageAsync()
    {
        var langString = await settingsRepository.GetSettingAsync(KeyLanguage).ConfigureAwait(false);
        return Enum.TryParse<Language>(langString, out var savedLanguage) ? savedLanguage : Constants.DefaultLanguage;
    }

    public Task SaveDefaultLanguageAsync(Language language)
    {
        return settingsRepository.SaveSettingAsync(KeyLanguage, language.ToString());
    }
}