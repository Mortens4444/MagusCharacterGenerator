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

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = StartDiscoverySafelyAsync();
    }

    private async Task StartDiscoverySafelyAsync()
    {
        try
        {
            if (BindingContext is not StorytellingViewModel vm)
            {
                return;
            }

            var discoveryStarted = await vm.StartDiscoveryAsync().ConfigureAwait(true);
            if (discoveryStarted == false)
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage("Bluetooth discovery cannot be started."));
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _ = StopBluetoothSafelyAsync();
    }

    private async Task StopBluetoothSafelyAsync()
    {
        try
        {
            if (BindingContext is not StorytellingViewModel vm)
            {
                return;
            }

            vm.StopDiscovery();
            await vm.StopServerAsync().ConfigureAwait(true);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }
}