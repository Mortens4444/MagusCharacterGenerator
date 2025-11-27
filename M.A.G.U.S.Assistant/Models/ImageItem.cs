namespace M.A.G.U.S.Assistant.Models;

internal class ImageItem
{
    public string ResourceId { get; set; } = String.Empty;

    public string DisplayName { get; set; } = String.Empty;

    public ImageSource Thumbnail
    {
        get
        {
            try
            {
                return ImageSource.FromFile(ResourceId);
            }
            catch
            {
                return null;
            }
        }
    }
}
