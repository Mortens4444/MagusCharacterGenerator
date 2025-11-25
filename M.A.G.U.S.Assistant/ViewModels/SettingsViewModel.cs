using CommunityToolkit.Mvvm.ComponentModel;
using M.A.G.U.S.Assistant.Services;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class SettingsViewModel : ObservableObject
{
    private readonly SettingsService settingsService;

    public SettingsViewModel(SettingsService settingsService)
    {
        this.settingsService = settingsService;
        Task.Run(async () =>
        {
            await settingsService.LoadAsync().ConfigureAwait(false);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                OnPropertyChanged(nameof(AddFightValueOnFirstLevelForAllClass));
                OnPropertyChanged(nameof(AddPainToleranceOnFirstLevelForAllClass));
                OnPropertyChanged(nameof(AddQualificationPointsOnFirstLevelForAllClass));
                OnPropertyChanged(nameof(AddManaPointsOnFirstLevelForAllClass));
                OnPropertyChanged(nameof(AddPsiPointsOnFirstLevelForAllClass));
            });
        });
    }

    public bool AddFightValueOnFirstLevelForAllClass
    {
        get => settingsService.AddFightValueOnFirstLevelForAllClass;
        set
        {
            if (settingsService.AddFightValueOnFirstLevelForAllClass != value)
            {
                settingsService.SaveAddFightValueAsync(value);
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
}
