using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Messages;
using ShowErrorMessage = M.A.G.U.S.Assistant.Messages.ShowErrorMessage;
using ShowInfoMessage = M.A.G.U.S.Assistant.Messages.ShowInfoMessage;

namespace M.A.G.U.S.Assistant.Views;

public partial class NotifierPage : ContentPage
{
    public NotifierPage()
    {
        WeakReferenceMessenger.Default.Register<ShowPage>(this, (sender, message) =>
        {
            _ = ShowPageHandler(message);
        });
        WeakReferenceMessenger.Default.Register<ShowInfoMessage>(this, (sender, message) =>
        {
            _ = DisplayAlert(message);
        });
        WeakReferenceMessenger.Default.Register<ShowErrorMessage>(this, (sender, message) =>
        {
            _ = DisplayError(message);
        });
    }

    private Task ShowPageHandler(ShowPage message)
    {
        return Navigation.PushAsync(message.Page);
    }

    private Task DisplayAlert(ShowInfoMessage message)
    {
        return DisplayAlert(message.Title, message.Message, "OK");
    }

    private Task DisplayError(ShowErrorMessage message)
    {
        return DisplayAlert("Error", message.Value, "OK");
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        WeakReferenceMessenger.Default.UnregisterAll(this);
    }
}
