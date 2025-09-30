namespace M.A.G.U.S.Assistant.Models;

public class DrawableShape
{
    public string Type { get; set; } = String.Empty;
    public float X { get; set; }
    public float Y { get; set; }
    public float Size { get; set; } = 60;
    public Color Color { get; set; } = Colors.Black;

    public string Description => $"{Type} @ {Math.Round(X)},{Math.Round(Y)}";
}
