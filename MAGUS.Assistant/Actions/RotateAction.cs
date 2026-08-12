using MAGUS.Assistant.Interfaces;

namespace MAGUS.Assistant.Actions;

internal sealed class RotateAction(IDrawableElement element, float deltaRotation) : IPaintAction
{
    private readonly IDrawableElement element = element;
    private readonly float deltaRotation = deltaRotation;

    public void Undo(IList<IDrawableElement> elements) => element.Rotate(-deltaRotation);
    public void Redo(IList<IDrawableElement> elements) => element.Rotate(deltaRotation);
}