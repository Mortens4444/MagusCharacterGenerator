using MAGUS.Assistant.Services;
using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

internal sealed partial class CharacterPortraitPickerPage : NotifierPage
{
    private readonly TaskCompletionSource<IReadOnlyList<string>?> tcs = new();
    private bool isClosing;

    public CharacterPortraitPickerPage(CharacterPortraitPickerViewModel viewModel)
    {
        InitializeComponent();

        viewModel.Confirmed += OnConfirmed;
        viewModel.Cancelled += OnCancelled;
        BindingContext = viewModel;
    }

    public Task<IReadOnlyList<string>?> ResultTask => tcs.Task;

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Translator.Translate(this);
    }

    private async void OnConfirmed(IReadOnlyList<string> resourceIds)
    {
        await CloseAsync(resourceIds).ConfigureAwait(true);
    }

    private async void OnCancelled()
    {
        await CloseAsync(null).ConfigureAwait(true);
    }

    private async Task CloseAsync(IReadOnlyList<string>? result)
    {
        if (isClosing)
        {
            return;
        }

        isClosing = true;
        await ShellNavigationService.CloseModalPageAsync().ConfigureAwait(true);
        tcs.TrySetResult(result);
    }
}
