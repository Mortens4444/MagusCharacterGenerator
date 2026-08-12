namespace MAGUS.Assistant.Interfaces;

internal interface IPaintAction
{
    void Undo(IList<IDrawableElement> elements);

    void Redo(IList<IDrawableElement> elements);
}
