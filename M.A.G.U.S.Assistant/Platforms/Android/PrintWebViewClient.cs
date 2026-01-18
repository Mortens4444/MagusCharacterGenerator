using Android.Content;
using Android.Print;
using Android.Webkit;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal class PrintWebViewClient(string jobName) : WebViewClient
{
    private readonly string jobName = jobName;

    public override void OnPageFinished(global::Android.Webkit.WebView? view, string? url)
    {
        if (view == null)
        {
            return;
        }

        var context = Platform.CurrentActivity;
        if (context?.GetSystemService(Context.PrintService) is PrintManager printManager)
        {
            var printAdapter = view.CreatePrintDocumentAdapter(jobName);
            printManager.Print(jobName, printAdapter, new PrintAttributes.Builder().Build());
        }
    }
}
