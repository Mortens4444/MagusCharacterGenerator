namespace M.A.G.U.S.Assistant.Interfaces;

internal interface IPrintService
{
    Task PrintHtmlAsync(string htmlContent, string jobName);
}
