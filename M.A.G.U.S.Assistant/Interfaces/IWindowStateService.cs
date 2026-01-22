namespace M.A.G.U.S.Assistant.Interfaces;

internal interface IWindowStateService
{
    void Attach(Window window);

    void Restore(Window window);
}
