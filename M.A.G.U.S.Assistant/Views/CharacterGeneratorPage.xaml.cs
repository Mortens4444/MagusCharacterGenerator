using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class CharacterGeneratorPage : NotifierPage
{
    private CharacterGeneratorViewModel ViewModel => (CharacterGeneratorViewModel)BindingContext;

    public CharacterGeneratorPage(CharacterGeneratorViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        Shell.Current.Navigating += Shell_Navigating;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Shell.Current.Navigating -= Shell_Navigating;
    }
    private async void Shell_Navigating(object? sender, ShellNavigatingEventArgs e)
    {
        if (!ViewModel.IsDirty || e.Current == null || e.Source == ShellNavigationSource.Push)
        {
            return;
        }

        e.Cancel();

        var answer = await ConfirmNavigationAsync().ConfigureAwait(true);
        if (answer)
        {
            ViewModel.MarkClean();
            await ShellNavigationService.GoToAsync(e.Target.Location).ConfigureAwait(true);
        }
    }

    private static Task<bool> ConfirmNavigationAsync()
    {
        return ShellNavigationService.DisplayAlertAsync(
            "Confirm navigation",
            "Are you sure you want to leave this page? Unsaved changes will be lost.",
            "Leave",
            "Stay");
    }

    protected override bool OnBackButtonPressed()
    {
        if (!ViewModel.IsDirty)
        {
            return false;
        }

        _ = HandleBackButtonAsync();

        return true;
    }

    private async Task HandleBackButtonAsync()
    {
        var answer = await ConfirmNavigationAsync().ConfigureAwait(true);
        if (answer)
        {
            ViewModel.MarkClean();
            await ShellNavigationService.GoBackAsync().ConfigureAwait(true);
        }
    }
}