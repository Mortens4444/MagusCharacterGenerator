using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Stubs;

internal class StubPrintService : IPrintService
{
    public Task PrintHtmlAsync(string h, string j) => Task.CompletedTask;
}
