using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class EncounterPage : NotifierPage
{
    public EncounterPage(EncounterViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is EncounterViewModel vm)
        {
            await vm.LoadCharactersAsync().ConfigureAwait(false);
            await vm.LoadBestiaryAsync().ConfigureAwait(false);
        }
    }
}
