using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class CharacterGeneratorPage : NotifierPage
{
    private bool canNavigate;

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
        if (canNavigate || e.Current == null)
        {
            return;
        }

        e.Cancel();
        var answer = await ConfirmNavigationAsync().ConfigureAwait(true);
        if (answer)
        {
            canNavigate = true;
            await Shell.Current.GoToAsync(e.Target.Location).ConfigureAwait(true);
        }
    }

    private static Task<bool> ConfirmNavigationAsync()
    {
        return Shell.Current.DisplayAlertAsync(
            Lng.Elem("Confirm navigation"),
            Lng.Elem("Are you sure you want to leave this page? Unsaved changes will be lost."),
            Lng.Elem("Leave"),
            Lng.Elem("Stay"));
    }

    protected override bool OnBackButtonPressed()
    {
        if (canNavigate)
        {
            return false;
        }

        _ = Dispatcher.Dispatch(async () =>
        {
            var answer = await ConfirmNavigationAsync().ConfigureAwait(true);
            if (answer)
            {
                canNavigate = true;
                await Shell.Current.GoToAsync("..");
            }
        });

        return true;
    }
}