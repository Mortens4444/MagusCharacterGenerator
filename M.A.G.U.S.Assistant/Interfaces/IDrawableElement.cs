namespace M.A.G.U.S.Assistant.Interfaces;

internal interface IDrawableElement
{
    Color Color { get; set; }

    void Draw(ICanvas canvas);
}
