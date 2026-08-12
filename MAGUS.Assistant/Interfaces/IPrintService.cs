namespace MAGUS.Assistant.Interfaces;

internal interface IPrintService
{
    Task PrintHtmlAsync(string htmlContent, string jobName);
}
