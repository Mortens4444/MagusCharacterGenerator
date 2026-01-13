using M.A.G.U.S.Assistant.Interfaces;
using UIKit;

namespace M.A.G.U.S.Assistant.Platforms.iOS;

internal sealed class PrintService : IPrintService
{
    public Task PrintHtmlAsync(string htmlContent, string jobName)
    {
        return MainThread.InvokeOnMainThreadAsync(() =>
        {
            var printInfo = UIPrintInfo.PrintInfo;
            printInfo.OutputType = UIPrintInfoOutputType.General;
            printInfo.JobName = jobName;

            using var formatter = new UIMarkupTextPrintFormatter(htmlContent);

            var controller = UIPrintInteractionController.SharedPrintController;
            controller.PrintInfo = printInfo;
            controller.PrintFormatter = formatter;

            controller.Present(true, (handler, completed, err) => { });
        });
    }
}