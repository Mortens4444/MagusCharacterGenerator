using CommunityToolkit.Mvvm.Messaging;
using MAGUS.Assistant.Interfaces;
using Microsoft.UI.Xaml.Controls;
using Mtf.Maui.Controls.Messages;

namespace MAGUS.Assistant.Platforms.Windows;

internal sealed class PrintService : IPrintService
{
    public async Task PrintHtmlAsync(string htmlContent, string jobName)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            var webView = new WebView2();

            await webView.EnsureCoreWebView2Async();

            webView.NavigateToString(htmlContent);

            bool navigationCompleted = false;
            webView.NavigationCompleted += (s, e) => navigationCompleted = true;

            while (!navigationCompleted)
            {
                await Task.Delay(100).ConfigureAwait(true);
            }

            try
            {
                await webView.CoreWebView2.PrintAsync(null);
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
            }
        }).ConfigureAwait(true);
    }
}
