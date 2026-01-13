using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Interfaces;
using Mtf.Maui.Controls.Messages;

namespace M.A.G.U.S.Assistant.Services;

internal class ShellNavigationService : INavigationService
{
    public static Task ShowAlert() => Shell.Current.DisplayAlertAsync("Title", "Message", "OK");

    public static Task ShowPage(Page page)
    {
        return MainThread.InvokeOnMainThreadAsync(async () =>
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
    }

    public static Task ClosePage()
    {
        return MainThread.InvokeOnMainThreadAsync(async () =>
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
    }

    public async Task NavigateToAsync(string route, object? parameter = null, bool animate = true)
    {
        if (String.IsNullOrWhiteSpace(route))
        {
            throw new ArgumentNullException(nameof(route));
        }

        if (parameter == null)
        {
            await Shell.Current.GoToAsync(route, animate: animate).ConfigureAwait(true);
            return;
        }

        var id = NavigationParameterStore.Put(parameter);
        var routed = $"{route}?paramId={Uri.EscapeDataString(id)}";
        await Shell.Current.GoToAsync(routed, animate: animate).ConfigureAwait(true);
    }

    public Task GoBackAsync(bool animate = true)
    {
        return Shell.Current.GoToAsync("..", animate: animate);
    }
}