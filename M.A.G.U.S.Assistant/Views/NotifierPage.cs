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
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
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

    private async Task DisplayError(ShowErrorMessage message)
    {
        var exceptionDetails = message.Value;
        if (message.Exception != null)
        {
            var stackTrace = new StackTrace(message.Exception, true);
            var exception = message.Exception;
            var frame = new StackTrace(exception, true).GetFrame(0);

            string callingMethod = frame?.GetMethod()?.Name ?? "N/A";
            string callingClass = frame?.GetMethod()?.DeclaringType?.FullName ?? "N/A";
            int lineNumber = frame?.GetFileLineNumber() ?? 0;

            string title = "ERROR: " + callingMethod;
            string fullMessage = $"{exceptionDetails}\n\n" +
                                 $"Source Class: {callingClass}\n" +
                                 $"Method: {callingMethod}\n" +
                                 $"Line: {lineNumber}\n\n" +
                                 $"Full Stack Trace:\n{exception.StackTrace}";
            await Clipboard.SetTextAsync(fullMessage).ConfigureAwait(false);
            await DisplayAlert(title, fullMessage, "OK").ConfigureAwait(false);
        }

        await DisplayAlert("Error", exceptionDetails, "OK").ConfigureAwait(false);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        WeakReferenceMessenger.Default.UnregisterAll(this);
    }
}
