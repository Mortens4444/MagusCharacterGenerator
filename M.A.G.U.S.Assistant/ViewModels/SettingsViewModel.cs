using CommunityToolkit.Mvvm.ComponentModel;
using M.A.G.U.S.Assistant.Database.Repositories;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class SettingsViewModel : ObservableObject
{
    private readonly SettingsRepository settingsRepository;

    private bool addQualificationPointsOnFirstLevelForAllClass = true;
    private bool addFightValueOnFirstLevelForAllClass = true;
    private bool addPainToleranceOnFirstLevelForAllClass = true;

    private const string KeyFightValue = "Setting_FightValueFirstLevel";
    private const string KeyPainTolerance = "Setting_PainToleranceFirstLevel";
    private const string KeyQualification = "Setting_QualificationPointsFirstLevel";

    public SettingsViewModel(SettingsRepository settingsRepository)
    {
        this.settingsRepository = settingsRepository;
        Task.Run(LoadSettingsAsync);
    }

    public bool AddFightValueOnFirstLevelForAllClass
    {
        get => addFightValueOnFirstLevelForAllClass;
        set
        {
            if (SetProperty(ref addFightValueOnFirstLevelForAllClass, value))
            {
                OnAddFightValueOnFirstLevelForAllClassChanged(value);
            }
        }
    }

    public void OnAddFightValueOnFirstLevelForAllClassChanged(bool value)
    {
        _ = settingsRepository.SaveBoolSettingAsync(KeyFightValue, value);
    }

    public bool AddPainToleranceOnFirstLevelForAllClass
    {
        get => addPainToleranceOnFirstLevelForAllClass;
        set
        {
            if (SetProperty(ref addPainToleranceOnFirstLevelForAllClass, value))
            {
                OnAddPainToleranceOnFirstLevelForAllClassChanged(value);
            }
        }
    }

    public void OnAddPainToleranceOnFirstLevelForAllClassChanged(bool value)
    {
        _ = settingsRepository.SaveBoolSettingAsync(KeyPainTolerance, value);
    }

    public bool AddQualificationPointsOnFirstLevelForAllClass
    {
        get => addQualificationPointsOnFirstLevelForAllClass;
        set
        {
            if (SetProperty(ref addQualificationPointsOnFirstLevelForAllClass, value))
            {
                OnAddQualificationPointsOnFirstLevelForAllClassChanged(value);
            }
        }
    }

    public void OnAddQualificationPointsOnFirstLevelForAllClassChanged(bool value)
    {
        _ = settingsRepository.SaveBoolSettingAsync(KeyQualification, value);
    }

    private async Task LoadSettingsAsync()
    {
        var fightVal = await settingsRepository.GetBoolSettingAsync(KeyFightValue, true).ConfigureAwait(false);
        var painVal = await settingsRepository.GetBoolSettingAsync(KeyPainTolerance, true).ConfigureAwait(false);
        var qualVal = await settingsRepository.GetBoolSettingAsync(KeyQualification, true).ConfigureAwait(false);

        MainThread.BeginInvokeOnMainThread(() =>
        {
            AddFightValueOnFirstLevelForAllClass = fightVal;
            AddPainToleranceOnFirstLevelForAllClass = painVal;
            AddQualificationPointsOnFirstLevelForAllClass = qualVal;
        });
    }
}
