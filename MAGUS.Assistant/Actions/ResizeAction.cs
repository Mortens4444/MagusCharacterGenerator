using MAGUS.Assistant.Interfaces;

namespace MAGUS.Assistant.Actions;

internal sealed class ResizeAction(IDrawableElement element, float scaleFactor) : IPaintAction
{
    private readonly IDrawableElement element = element;
    private readonly float scaleFactor = scaleFactor;

    public void Undo(IList<IDrawableElement> elements)
    {
        if (scaleFactor != 0)
        {
            element.Resize(1.0f / scaleFactor);
        }
    }

    public void Redo(IList<IDrawableElement> elements)
    {
        element.Resize(scaleFactor);
    }
}