using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class CharactersPage : NotifierPage
{
    public CharactersPage(CharactersViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is CharactersViewModel vm)
        {
            await vm.LoadCharactersAsync().ConfigureAwait(false);
        }
    }
}