using CommunityToolkit.Mvvm.Messaging;
using Mtf.LanguageService.MAUI;
using Mtf.Maui.Controls.Messages;

namespace M.A.G.U.S.Assistant.Services;

internal static class ShellNavigationService
{
    public static Task DisplayAlertAsync(string message)
    {
        return DisplayAlertAsync("Alert", message);
    }

    public static Task DisplayAlertAsync(string title, string message, string? ok = null)
    {
        return MainThread.InvokeOnMainThreadAsync(async () =>
        {
            try
            {
                await Shell.Current.DisplayAlertAsync(Lng.Elem(title), Lng.Elem(message), Lng.Elem(ok ?? "OK")).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
            }
        });
    }

    public static Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel)
    {
        return MainThread.InvokeOnMainThreadAsync(async () =>
        {
            try
            {
                return await Shell.Current.DisplayAlertAsync(Lng.Elem(title), Lng.Elem(message), Lng.Elem(accept), Lng.Elem(cancel)).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
                return false;
            }
        });
    }

    public static Task ShowPageAsync(Page page) => MainThread.InvokeOnMainThreadAsync(async () =>
        {
            try
            {
                await Shell.Current.Navigation.PushAsync(page).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
            }
        });

    public static Task ClosePageAsync() => MainThread.InvokeOnMainThreadAsync(async () =>
        {
            try
            {
                await Shell.Current.Navigation.PopAsync().ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
            }
        });

    public static Task NavigateToAsync(string route, object? parameter = null, bool animate = true)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(route, nameof(route));

        if (parameter == null)
        {
            return Shell.Current.GoToAsync(route, animate: animate);
        }

        var id = NavigationParameterStore.Put(parameter);
        var routed = $"{route}?paramId={Uri.EscapeDataString(id)}";
        return Shell.Current.GoToAsync(routed, animate: animate);
    }

    public static Task GoBackAsync(bool animate = true) => Shell.Current.GoToAsync("..", animate: animate);

    public static Task<string?> DisplayPromptAsync(
        string title,
        string message,
        string accept = "OK",
        string cancel = "Cancel",
        string initialValue = "")
        => MainThread.InvokeOnMainThreadAsync(() =>
            Shell.Current.DisplayPromptAsync(
                Lng.Elem(title),
                Lng.Elem(message),
                Lng.Elem(accept),
                Lng.Elem(cancel),
                Lng.Elem(initialValue)));

    public static Task GoToAsync(Uri uri, bool animate = true) => Shell.Current.GoToAsync(uri, animate: animate);
}