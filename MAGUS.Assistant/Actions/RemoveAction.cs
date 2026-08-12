using MAGUS.Assistant.Interfaces;

namespace MAGUS.Assistant.Actions;

internal sealed class RemoveAction(IDrawableElement element) : IPaintAction
{
    private readonly IDrawableElement element = element;

    public void Undo(IList<IDrawableElement> elements)
    {
        elements.Add(element);
    }

    public void Redo(IList<IDrawableElement> elements)
    {
        elements.Remove(element);
    }
}
