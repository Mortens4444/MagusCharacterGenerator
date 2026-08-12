using CommunityToolkit.Mvvm.Messaging;
using MAGUS.Assistant.Services;
using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService;
using Mtf.LanguageService.MAUI.Views;
using Mtf.Maui.Controls.Messages;

namespace MAGUS.Assistant.Views;

internal sealed partial class ItemDetailsPage : NotifierPage
{
    public ItemDetailsPage(ItemDetailsViewModel itemDetailsViewModel)
    {
        InitializeComponent();
        Title = Lng.Elem(itemDetailsViewModel.ThingToBuy.Name);
        BindingContext = itemDetailsViewModel;
        itemDetailsViewModel.Closed += OnVmClosed;
    }

    private async void OnVmClosed(object? sender, EventArgs e)
    {
        try
        {
            await ShellNavigationService.GoBackAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }
}
