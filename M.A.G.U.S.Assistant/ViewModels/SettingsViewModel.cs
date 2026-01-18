using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.Services;
using Mtf.LanguageService.Enums;
using System.Reflection;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class SettingsViewModel : BaseViewModel
{
    private readonly SettingsService settingsService;
    
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
        ToggleSettingCommand = new RelayCommand<object?>(ToggleSetting);
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

    public Language CurrentLanguage
    {
        get => settingsService.GetCurrentLanguageAsync().GetAwaiter().GetResult();
        set
        {
            settingsService.SaveDefaultLanguageAsync(value);
            OnPropertyChanged();
        }
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
