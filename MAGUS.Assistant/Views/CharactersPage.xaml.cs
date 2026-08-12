using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

internal sealed partial class CharactersPage : NotifierPage
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