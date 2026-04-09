using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;
using Mtf.Maui.Controls.Messages;

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
            var discoveryStarted = await vm.StartDiscoveryAsync().ConfigureAwait(true);
            if (!discoveryStarted)
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage("Bluetooth discovery cannot be started."));
            }
        }
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();

        if (BindingContext is StorytellingViewModel vm)
        {
            await vm.StopServerAsync().ConfigureAwait(true);
        }
    }
}