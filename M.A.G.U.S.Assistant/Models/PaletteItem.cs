namespace M.A.G.U.S.Assistant.Models;

public class PaletteItem
{
    public string Id { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string Image { get; set; } = String.Empty; // image path or resource
    public int WidthCm { get; set; }
    public int HeightCm { get; set; }
    public string SizeDisplay => $"{WidthCm}×{HeightCm} cm";
}
