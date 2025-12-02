using M.A.G.U.S.Assistant.Database.Repositories;
using M.A.G.U.S.Interfaces;
using Mtf.LanguageService.Enums;

namespace M.A.G.U.S.Assistant.Services;

internal sealed class SettingsService : ISettings
{
    private readonly SettingsRepository settingsRepository;

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

    public SettingsService(SettingsRepository settingsRepository)
    {
        this.settingsRepository = settingsRepository;
        LoadAsync().GetAwaiter().GetResult();
    }

    private async Task LoadAsync()
    {
        AddFightValueOnFirstLevelForAllClass = await settingsRepository.GetBoolSettingAsync(KeyFightValue, Constants.AddFightValueOnFirstLevelForAllClass).ConfigureAwait(false);
        AddPainToleranceOnFirstLevelForAllClass = await settingsRepository.GetBoolSettingAsync(KeyPainTolerance, Constants.AddPainToleranceOnFirstLevelForAllClass).ConfigureAwait(false);
        AddQualificationPointsOnFirstLevelForAllClass = await settingsRepository.GetBoolSettingAsync(KeyQualification, Constants.AddQualificationPointsOnFirstLevelForAllClass).ConfigureAwait(false);
        AddManaPointsOnFirstLevelForAllClass = await settingsRepository.GetBoolSettingAsync(KeyMana, Constants.AddManaPointsOnFirstLevelForAllClass).ConfigureAwait(false);
        AddPsiPointsOnFirstLevelForAllClass = await settingsRepository.GetBoolSettingAsync(KeyPsi, Constants.AddPsiPointsOnFirstLevelForAllClass).ConfigureAwait(false);

        AutoDistributeCombatValues = await settingsRepository.GetBoolSettingAsync(KeyCombatValue, Constants.AutoDistributeCombatValues).ConfigureAwait(false);
        AutoDistributeQualificationPoints = await settingsRepository.GetBoolSettingAsync(KeyQualificationPoints, Constants.AutoDistributeQualificationPoints).ConfigureAwait(false);
        AutoIncreasePainTolerance = await settingsRepository.GetBoolSettingAsync(KeyPainToleranceIncrease, Constants.AutoIncreasePainTolerance).ConfigureAwait(false);
        AutoGenerateSkills = await settingsRepository.GetBoolSettingAsync(KeySkills, Constants.AutoGenerateSkills).ConfigureAwait(false);
    }

    public Task SaveAddFightValueAsync(bool value)
    {
        AddFightValueOnFirstLevelForAllClass = value;
        return settingsRepository.SaveBoolSettingAsync(KeyFightValue, value);
    }

    public Task SaveAddPainToleranceAsync(bool value)
    {
        AddPainToleranceOnFirstLevelForAllClass = value;
        return settingsRepository.SaveBoolSettingAsync(KeyPainTolerance, value);
    }

    public Task SaveAddQualificationAsync(bool value)
    {
        AddQualificationPointsOnFirstLevelForAllClass = value;
        return settingsRepository.SaveBoolSettingAsync(KeyQualification, value);
    }

    public Task SaveAddManaAsync(bool value)
    {
        AddManaPointsOnFirstLevelForAllClass = value;
        return settingsRepository.SaveBoolSettingAsync(KeyMana, value);
    }

    public Task SaveAddPsiAsync(bool value)
    {
        AddPsiPointsOnFirstLevelForAllClass = value;
        return settingsRepository.SaveBoolSettingAsync(KeyPsi, value);
    }

    public Task SaveAutoCombatValueDistributionAsync(bool value)
    {
        AutoDistributeCombatValues = value;
        return settingsRepository.SaveBoolSettingAsync(KeyCombatValue, value);
    }

    public Task SaveAutoQualificationPointsDistributionAsync(bool value)
    {
        AutoDistributeQualificationPoints = value;
        return settingsRepository.SaveBoolSettingAsync(KeyQualificationPoints, value);
    }

    public Task SaveAutoPainToleranceIncreaseAsync(bool value)
    {
        AutoIncreasePainTolerance = value;
        return settingsRepository.SaveBoolSettingAsync(KeyPainToleranceIncrease, value);
    }

    public Task SaveAutoGenerateSkillsAsync(bool value)
    {
        AutoGenerateSkills = value;
        return settingsRepository.SaveBoolSettingAsync(KeySkills, value);
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