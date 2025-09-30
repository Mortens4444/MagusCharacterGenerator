using System.ComponentModel;
using System.Reflection;

namespace M.A.G.U.S.Assistant.Models;

public class ImageItem : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public string ResourceId { get; set; } = String.Empty;
    public string DisplayName { get; set; } = String.Empty;

    // Thumbnail ImageSource from embedded resource
    public ImageSource Thumbnail
    {
        get
        {
            try
            {
                var asm = Assembly.GetExecutingAssembly();
                return ImageSource.FromResource(ResourceId, asm);
            }
            catch
            {
                return null;
            }
        }
    }
}
