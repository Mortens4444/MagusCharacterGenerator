using Android.Content;
using Android.Print;
using Android.Webkit;
using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal sealed class PrintService : IPrintService
{
    public Task PrintHtmlAsync(string htmlContent, string jobName)
    {
        var context = Platform.CurrentActivity;
        if (context == null) return Task.CompletedTask;

        // CA2000 elkerülése: A WebView-t nem tudjuk 'using'-ba tenni, 
        // mert a nyomtatás aszinkron a háttérben fut. 
        // A GC-re bízzuk, de a figyelmeztetést elnyomhatjuk vagy manuálisan kezelhetjük.
        var webView = new global::Android.Webkit.WebView(context);

        webView.SetWebViewClient(new WebViewClient());
        webView.LoadDataWithBaseURL(null, htmlContent, "text/html", "UTF-8", null);

        webView.PostDelayed(() =>
        {
            if (context.GetSystemService(Context.PrintService) is PrintManager printManager)
            {
                using var printAdapter = webView.CreatePrintDocumentAdapter(jobName);
                printManager.Print(jobName, printAdapter, new PrintAttributes.Builder().Build());
            }
            // Opcionális: webView.Dispose() hívása a nyomtatás után, ha kész a job
        }, 1500);

        return Task.CompletedTask;
    }
}