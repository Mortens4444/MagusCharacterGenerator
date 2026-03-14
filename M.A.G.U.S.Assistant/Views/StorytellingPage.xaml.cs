using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class StorytellingPage : NotifierPage
{
	public StorytellingPage(StorytellingViewModel storytellingViewModel)
	{
		InitializeComponent();
		BindingContext = storytellingViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is StorytellingViewModel vm)
        {
            await vm.StartDiscoveryAsync();
        }
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();

        if (BindingContext is StorytellingViewModel vm)
        {
            await vm.StopServerAsync();
        }
    }
}