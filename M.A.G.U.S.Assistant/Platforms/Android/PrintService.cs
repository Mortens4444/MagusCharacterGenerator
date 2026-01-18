using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal sealed class PrintService : IPrintService
{
    public Task PrintHtmlAsync(string htmlContent, string jobName)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            var context = Platform.CurrentActivity;
            if (context == null)
            {
                return;
            }

            var webView = new global::Android.Webkit.WebView(context);
            webView.SetWebViewClient(new PrintWebViewClient(jobName));
            webView.LoadDataWithBaseURL(null, htmlContent, "text/html", "UTF-8", null);
        });

        return Task.CompletedTask;
    }
}
