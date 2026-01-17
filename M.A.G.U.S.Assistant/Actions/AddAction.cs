using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Actions;

internal class AddAction(IDrawableElement element) : IPaintAction
{
    private readonly IDrawableElement element = element;

    public void Undo(IList<IDrawableElement> elements)
    {
        elements.Remove(element);
    }

    public void Redo(IList<IDrawableElement> elements)
    {
        elements.Add(element);
    }
}
