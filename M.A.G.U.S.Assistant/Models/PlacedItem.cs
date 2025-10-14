namespace M.A.G.U.S.Assistant.Models;

public class PlacedItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string PaletteItemId { get; set; } = String.Empty;
    public int X { get; set; } // left (cm)
    public int Y { get; set; } // top (cm)
    public int Width { get; set; }
    public int Height { get; set; }
    public string Image { get; set; } = String.Empty;
}
