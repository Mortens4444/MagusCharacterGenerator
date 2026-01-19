using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Models.Drawing;

internal class TextElement : IDrawableElement
{
    public required string Text { get; set; }

    public required Color Color { get; set; }

    public PointF Position { get; set; }

    public float FontSize { get; set; } = 18;
    
    public float Rotation { get; set; }

    public bool Contains(PointF point)
    {
        if (String.IsNullOrEmpty(Text))
        {
            return false;
        }

        // Becsült szélesség: a karakterek száma szorozva a betűméret egy részével.
        // A 0.6f egy átlagos szorzó a legtöbb betűtípushoz (monospace-nél pontosabb, arányosnál biztonsági ráhagyás).
        float estimatedWidth = Text.Length * (FontSize * 0.6f);

        // A magasság maga a FontSize. 
        // Mivel a DrawString alapértelmezett horgonypontja (VerticalAlignment) változhat, 
        // érdemes a pozíció köré egy kis függőleges puffert is tenni.
        float height = FontSize;

        // A szöveg téglalapja:
        // X: A kezdőponttól a becsült szélességig
        // Y: A pozíciótól felfelé eltolva (mivel a szöveget általában a 'baseline'-ra rajzoljuk)
        var textBounds = new RectF(
            Position.X,
            Position.Y - (height * 0.8f), // Felfelé eltoljuk, hogy a betűk "testét" fedje
            estimatedWidth,
            height * 1.2f // 20% ráhagyás alul-felül a könnyebb kijelöléshez
        );

        return textBounds.Contains(point);
    }

    public void Draw(ICanvas canvas)
    {
        canvas.FontColor = Color;
        canvas.FontSize = FontSize;
        canvas.DrawString(Text, Position.X, Position.Y, HorizontalAlignment.Left);
    }

    public void Move(float dx, float dy)
    {
        Position = new PointF(Position.X + dx, Position.Y + dy);
    }

    public PointF GetCenter()
    {
        return Position;
    }

    public void Rotate(float angleDegrees)
    {
        Rotation += angleDegrees;
    }

    public void Resize(float scale)
    {
        if (scale <= 0) return;

        // A betűméretet skálázzuk
        FontSize *= scale;

        // Opcionális: limitálhatjuk a méretet, hogy ne lehessen olvashatatlanul kicsi vagy óriási
        if (FontSize < 8) FontSize = 8;
        if (FontSize > 200) FontSize = 200;
    }
}
