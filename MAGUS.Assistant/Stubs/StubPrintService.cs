using MAGUS.Assistant.Interfaces;

namespace MAGUS.Assistant.Stubs;

internal sealed class StubPrintService : IPrintService
{
    public Task PrintHtmlAsync(string h, string j) => Task.CompletedTask;
}
