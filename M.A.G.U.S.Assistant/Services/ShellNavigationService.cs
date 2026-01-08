using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Interfaces;
using Mtf.Maui.Controls.Messages;

namespace M.A.G.U.S.Assistant.Services;

internal class ShellNavigationService : INavigationService
{
    public static async Task ShowPage(Page page)
    {
        try
        {
            var mainPage = Application.Current != null && Application.Current.Windows.Count > 0 ? Application.Current.Windows[0].Page : null;
            if (mainPage?.Navigation != null)
            {
                await mainPage.Navigation.PushAsync(page).ConfigureAwait(true);
            }
            else
            {
                throw new InvalidOperationException("Main page or navigation is not available");
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    public static async Task ClosePage()
    {
        try
        {
            var mainPage = Application.Current != null && Application.Current.Windows.Count > 0 ? Application.Current.Windows[0].Page : null;
            if (mainPage?.Navigation != null)
            {
                await mainPage.Navigation.PopAsync().ConfigureAwait(true);
            }
            else
            {
                throw new InvalidOperationException("Main page or navigation is not available");
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }

    }

    public async Task NavigateToAsync(string route, object? parameter = null, bool animate = true)
    {
        if (String.IsNullOrWhiteSpace(route))
        {
            throw new ArgumentNullException(nameof(route));
        }

        if (parameter == null)
        {
            await Shell.Current.GoToAsync(route, animate: animate).ConfigureAwait(false);
            return;
        }

        var id = NavigationParameterStore.Put(parameter);
        var routed = $"{route}?paramId={Uri.EscapeDataString(id)}";
        await Shell.Current.GoToAsync(routed, animate: animate).ConfigureAwait(false);
    }

    public Task GoBackAsync(bool animate = true)
    {
        return Shell.Current.GoToAsync("..", animate: animate);
    }
}