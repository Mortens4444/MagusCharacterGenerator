using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Services;

internal class ShellNavigationService : INavigationService
{
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