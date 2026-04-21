using CommunityToolkit.Mvvm.ComponentModel;
using M.A.G.U.S.Assistant.Services;
using Mtf.LanguageService.Enums;
using System.Threading.Tasks;

namespace M.A.G.U.S.Assistant.ViewModels;

internal class MainPageViewModel : BaseViewModel
{
    private readonly SettingsService settingsService;

    private Language currentLanguage;

    public MainPageViewModel(SettingsService settingsService)
    {
        this.settingsService = settingsService;
    }

    public Language CurrentLanguage
    {
        get => currentLanguage;
        private set => SetProperty(ref currentLanguage, value);
    }

    public async Task InitializeAsync()
    {
        try
        {
            var lang = await settingsService.GetCurrentLanguageAsync().ConfigureAwait(false);
            CurrentLanguage = lang;
        }
        catch
        {
            // ignore
        }
    }
}
