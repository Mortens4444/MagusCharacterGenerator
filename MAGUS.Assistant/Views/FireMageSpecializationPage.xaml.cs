using MAGUS.Assistant.Services;
using MAGUS.Assistant.ViewModels;
using MAGUS.Enums;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

/// <summary>The level-5 "choose your Fire Mage path" modal - see CharacterViewModel.CheckPendingFireMageSpecializationAsync.</summary>
internal sealed partial class FireMageSpecializationPage : NotifierPage
{
    private bool isClosing;
    private readonly TaskCompletionSource<FireMageSpecialization> tcs = new();

    public FireMageSpecializationPage()
    {
        InitializeComponent();
        BindingContext = new FireMageSpecializationViewModel();
        ViewModel.CloseRequested += async (_, _) => await CloseAsync().ConfigureAwait(true);
    }

    public Task<FireMageSpecialization> ResultTask => tcs.Task;

    public FireMageSpecializationViewModel ViewModel => BindingContext as FireMageSpecializationViewModel
        ?? throw new ArgumentNullException(nameof(BindingContext), $"{nameof(BindingContext)} should be convertable to {nameof(FireMageSpecializationViewModel)}");

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Translator.Translate(this);
    }

    private async Task CloseAsync()
    {
        if (!isClosing)
        {
            isClosing = true;
            await ShellNavigationService.CloseModalPageAsync().ConfigureAwait(true);
            tcs.TrySetResult(ViewModel.SelectedSpecialization);
        }
    }
}
