using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Actions;

internal class RotateAction(IDrawableElement element, float deltaRotation) : IPaintAction
{
    private readonly IDrawableElement element = element;
    private readonly float deltaRotation = deltaRotation;

    public void Undo(IList<IDrawableElement> elements) => element.Rotate(-deltaRotation);
    public void Redo(IList<IDrawableElement> elements) => element.Rotate(deltaRotation);
}