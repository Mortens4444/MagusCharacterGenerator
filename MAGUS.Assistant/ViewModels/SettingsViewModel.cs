using CommunityToolkit.Mvvm.Input;
using MAGUS.Assistant.Services;
using MAGUS.Enums;
using Mtf.Extensions;
using Mtf.LanguageService.Enums;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Input;

namespace MAGUS.Assistant.ViewModels;

internal sealed partial class SettingsViewModel : BaseViewModel
{
    private readonly SettingsService settingsService;

    public ObservableCollection<CombatSimulatorMode> CombatSimulatorModes { get; } = [];

    public ICommand ToggleSettingCommand { get; }

    public SettingsViewModel(SettingsService settingsService)
    {
        this.settingsService = settingsService;
        OnPropertyChanged(nameof(AddCombatValueModifierPointsOnFirstLevelForAllClass));
        OnPropertyChanged(nameof(AddPainToleranceOnFirstLevelForAllClass));
        OnPropertyChanged(nameof(AddQualificationPointsOnFirstLevelForAllClass));
        OnPropertyChanged(nameof(AddManaPointsOnFirstLevelForAllClass));
        OnPropertyChanged(nameof(AddPsiPointsOnFirstLevelForAllClass));

        OnPropertyChanged(nameof(AutoDistributeCombatValues));
        OnPropertyChanged(nameof(AutoDistributeQualificationPoints));
        OnPropertyChanged(nameof(AutoGenerateSkills));
        OnPropertyChanged(nameof(AutoIncreasePainTolerance));
        OnPropertyChanged(nameof(AutoIncreaseManaPoints));
        OnPropertyChanged(nameof(MaxDiesCount));
        OnPropertyChanged(nameof(UseRaceClassRestrictions));
        OnPropertyChanged(nameof(CombatSimulatorMode));
        OnPropertyChanged(nameof(RestoreHealthPointsPerHourOfSleepString));
        OnPropertyChanged(nameof(RestorePainTolerancePointsPerHourOfSleepString));
        OnPropertyChanged(nameof(RestoreManaPointsPerHourOfSleepString));
        OnPropertyChanged(nameof(RestorePsiPointsPerHourOfSleepString));
        ToggleSettingCommand = new RelayCommand<object?>(ToggleSetting);

        var combatSimulatorModes = Enum.GetValues<CombatSimulatorMode>().Cast<CombatSimulatorMode>()
            .OrderBy(l => l.GetDescription())
            .ToList();

        CombatSimulatorModes.Clear();
        foreach (var combatSimulatorMode in combatSimulatorModes)
        {
            CombatSimulatorModes.Add(combatSimulatorMode);
        }
        CombatSimulatorMode = settingsService.GetCombatSimulatorModeAsync().GetAwaiter().GetResult();
    }

    public bool AddCombatValueModifierPointsOnFirstLevelForAllClass
    {
        get => settingsService.AddCombatValueOnFirstLevelForAllClass;
        set
        {
            if (settingsService.AddCombatValueOnFirstLevelForAllClass != value)
            {
                settingsService.SaveAddCombatValueAsync(value);
                OnPropertyChanged();
            }
        }
    }

    public bool AddPainToleranceOnFirstLevelForAllClass
    {
        get => settingsService.AddPainToleranceOnFirstLevelForAllClass;
        set
        {
            if (settingsService.AddPainToleranceOnFirstLevelForAllClass != value)
            {
                settingsService.SaveAddPainToleranceAsync(value);
                OnPropertyChanged();
            }
        }
    }

    public bool AddQualificationPointsOnFirstLevelForAllClass
    {
        get => settingsService.AddQualificationPointsOnFirstLevelForAllClass;
        set
        {
            if (settingsService.AddQualificationPointsOnFirstLevelForAllClass != value)
            {
                settingsService.SaveAddQualificationAsync(value);
                OnPropertyChanged();
            }
        }
    }

    public bool AddManaPointsOnFirstLevelForAllClass
    {
        get => settingsService.AddManaPointsOnFirstLevelForAllClass;
        set
        {
            if (settingsService.AddManaPointsOnFirstLevelForAllClass != value)
            {
                settingsService.SaveAddManaAsync(value);
                OnPropertyChanged();
            }
        }
    }

    public bool AddPsiPointsOnFirstLevelForAllClass
    {
        get => settingsService.AddPsiPointsOnFirstLevelForAllClass;
        set
        {
            if (settingsService.AddPsiPointsOnFirstLevelForAllClass != value)
            {
                settingsService.SaveAddPsiAsync(value);
                OnPropertyChanged();
            }
        }
    }

    public bool AutoDistributeCombatValues
    {
        get => settingsService.AutoDistributeCombatValues;
        set
        {
            if (settingsService.AutoDistributeCombatValues != value)
            {
                settingsService.SaveAutoCombatValueDistributionAsync(value);
                OnPropertyChanged();
            }
        }
    }

    public bool AutoDistributeQualificationPoints
    {
        get => settingsService.AutoDistributeQualificationPoints;
        set
        {
            if (settingsService.AutoDistributeQualificationPoints != value)
            {
                settingsService.SaveAutoQualificationPointsDistributionAsync(value);
                OnPropertyChanged();
            }
        }
    }

    public bool AutoGenerateSkills
    {
        get => settingsService.AutoGenerateSkills;
        set
        {
            if (settingsService.AutoGenerateSkills != value)
            {
                settingsService.SaveAutoGenerateSkillsAsync(value);
                OnPropertyChanged();
            }
        }
    }

    public bool AutoIncreasePainTolerance
    {
        get => settingsService.AutoIncreasePainTolerance;
        set
        {
            if (settingsService.AutoIncreasePainTolerance != value)
            {
                settingsService.SaveAutoPainToleranceIncreaseAsync(value);
                OnPropertyChanged();
            }
        }
    }

    public bool AutoIncreaseManaPoints
    {
        get => settingsService.AutoIncreaseManaPoints;
        set
        {
            if (settingsService.AutoIncreaseManaPoints != value)
            {
                settingsService.SaveAutoManaIncreaseAsync(value);
                OnPropertyChanged();
            }
        }
    }

    public int MaxDiesCount
    {
        get => settingsService.MaxDiesCount;
        set
        {
            if (settingsService.MaxDiesCount != value)
            {
                settingsService.SaveMaxDiesCountAsync(value);
                OnPropertyChanged();
            }
        }
    }

    public bool UseRaceClassRestrictions
    {
        get => settingsService.UseRaceClassRestrictions;
        set
        {
            if (settingsService.UseRaceClassRestrictions != value)
            {
                settingsService.SaveUseRaceClassRestrictionsAsync(value);
                OnPropertyChanged();
            }
        }
    }

    public bool AssignmentTurnHistoryNewestOnTop
    {
        get => settingsService.AssignmentTurnHistoryNewestOnTop;
        set
        {
            if (settingsService.AssignmentTurnHistoryNewestOnTop != value)
            {
                settingsService.SaveAssignmentTurnHistoryNewestOnTop(value);
                OnPropertyChanged();
            }
        }
    }

    public bool ShowRandomBeastWhenBestiaryPageOpened
    {
        get => settingsService.ShowRandomBeastWhenBestiaryPageOpened;
        set
        {
            if (settingsService.ShowRandomBeastWhenBestiaryPageOpened != value)
            {
                settingsService.SaveShowRandomBeastWhenBestiaryPageOpened(value);
                OnPropertyChanged();
            }
        }
    }

    public Language CurrentLanguage
    {
        get => settingsService.GetCurrentLanguageAsync().GetAwaiter().GetResult();
        set
        {
            settingsService.SaveDefaultLanguageAsync(value);
            OnPropertyChanged();
        }
    }

    public CombatSimulatorMode CombatSimulatorMode
    {
        get => settingsService.GetCombatSimulatorModeAsync().GetAwaiter().GetResult();
        set
        {
            settingsService.SaveCombatSimulatorModeAsync(value);
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Pickers with a converter-based ItemDisplayBinding (e.g. CombatSimulatorMode, translated via
    /// EnumDescriptionTranslationConverter) only re-run that converter when their ItemsSource raises
    /// a collection-changed event or their SelectedItem changes - not when the language changes
    /// elsewhere. Re-adding the items forces the picker to redraw with the newly selected language.
    /// </summary>
    public void RefreshLanguageDependentBindings()
    {
        var modes = CombatSimulatorModes.ToList();
        CombatSimulatorModes.Clear();
        foreach (var mode in modes)
        {
            CombatSimulatorModes.Add(mode);
        }
        OnPropertyChanged(nameof(CombatSimulatorMode));
    }

    public string RestoreHealthPointsPerHourOfSleepString
    {
        get => settingsService.RestoreHealthPointsPerHourOfSleep.ToString(CultureInfo.InvariantCulture);
        set
        {
            if (TryParseNonNegativeInt(value, out var parsed) && settingsService.RestoreHealthPointsPerHourOfSleep != parsed)
            {
                settingsService.SaveRestoreHealthPointsPerHourOfSleepAsync(parsed);
                OnPropertyChanged();
            }
        }
    }

    public string RestorePainTolerancePointsPerHourOfSleepString
    {
        get => settingsService.RestorePainTolerancePointsPerHourOfSleep.ToString(CultureInfo.InvariantCulture);
        set
        {
            if (TryParseNonNegativeInt(value, out var parsed) && settingsService.RestorePainTolerancePointsPerHourOfSleep != parsed)
            {
                settingsService.SaveRestorePainTolerancePointsPerHourOfSleepAsync(parsed);
                OnPropertyChanged();
            }
        }
    }

    public string RestoreManaPointsPerHourOfSleepString
    {
        get => settingsService.RestoreManaPointsPerHourOfSleep.ToString(CultureInfo.InvariantCulture);
        set
        {
            if (TryParseNonNegativeInt(value, out var parsed) && settingsService.RestoreManaPointsPerHourOfSleep != parsed)
            {
                settingsService.SaveRestoreManaPointsPerHourOfSleepAsync(parsed);
                OnPropertyChanged();
            }
        }
    }

    public string RestorePsiPointsPerHourOfSleepString
    {
        get => settingsService.RestorePsiPointsPerHourOfSleep.ToString(CultureInfo.InvariantCulture);
        set
        {
            if (TryParseNonNegativeInt(value, out var parsed) && settingsService.RestorePsiPointsPerHourOfSleep != parsed)
            {
                settingsService.SaveRestorePsiPointsPerHourOfSleepAsync(parsed);
                OnPropertyChanged();
            }
        }
    }

    private static bool TryParseNonNegativeInt(string? value, out int parsed)
    {
        return Int32.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out parsed) && parsed >= 0;
    }

    private void ToggleSetting(object? parameter)
    {
        var name = parameter as string;
        if (String.IsNullOrEmpty(name))
        {
            return;
        }

        var prop = GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
        if (prop == null)
        {
            return;
        }

        if (prop.PropertyType != typeof(bool))
        {
            return;
        }

        if (!prop.CanRead || !prop.CanWrite)
        {
            return;
        }

        var valueObj = prop.GetValue(this);
        if (valueObj is not bool current)
        {
            return;
        }

        prop.SetValue(this, !current);
    }
}
