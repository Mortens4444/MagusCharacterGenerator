using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Models;

namespace M.A.G.U.S.Assistant.Views;

internal partial class ItemDetailsPage : NotifierPage
{
    public ItemDetailsPage(ItemDetailsViewModel itemDetailsViewModel)
    {
        InitializeComponent();
        Title = Lng.Elem(itemDetailsViewModel.Thing.Name);
        BindingContext = itemDetailsViewModel;
        itemDetailsViewModel.Closed += OnVmClosed;
    }

    private async void OnVmClosed(object? sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync("..").ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }
}
