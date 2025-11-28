using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Messages;
using Mtf.LanguageService.MAUI;
using Mtf.Maui.Controls.Models;
using System.Diagnostics;

namespace M.A.G.U.S.Assistant.Views;

internal partial class NotifierPage : ContentPage
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

    protected override void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            _ = Translator.Translate(this);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Translate error: {ex}");
        }
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
