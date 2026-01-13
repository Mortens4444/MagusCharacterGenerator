using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Platforms.Tizen;

internal sealed class PrintService : IPrintService
{
    public Task PrintHtmlAsync(string htmlContent, string jobName)
    {
        return MainThread.InvokeOnMainThreadAsync(async () =>
        {
            await Shell.Current.DisplayAlert(Lng.Elem("Print"), Lng.Elem("Printing is not supported currently on this platform."), "OK");
        });
    }
}