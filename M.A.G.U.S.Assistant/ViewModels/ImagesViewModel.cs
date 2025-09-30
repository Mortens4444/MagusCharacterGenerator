using M.A.G.U.S.Assistant.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

public class ImagesViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableCollection<ImageItem> AllImages { get; } = new ObservableCollection<ImageItem>();
    public ObservableCollection<ImageItem> FilteredImages { get; } = new ObservableCollection<ImageItem>();

    private string searchText = String.Empty;
    public string SearchText
    {
        get => searchText;
        set
        {
            if (searchText == value) return;
            searchText = value;
            OnPropertyChanged(nameof(SearchText));
            ApplyFilter();
        }
    }

    private ImageItem selectedImage;
    public ImageItem SelectedImage
    {
        get => selectedImage;
        set
        {
            if (selectedImage == value) return;
            selectedImage = value;
            OnPropertyChanged(nameof(SelectedImage));
            if (selectedImage != null) Preview(selectedImage);
        }
    }

    public ICommand PreviewCommand { get; }

    public ImagesViewModel()
    {
        PreviewCommand = new Command<ImageItem>(Preview);
        LoadImages();
        ApplyFilter();
    }

    private void LoadImages()
    {
        try
        {
            var asm = Assembly.GetExecutingAssembly();
            var names = asm.GetManifestResourceNames()
                .Where(n => n.IndexOf(".Resources.Images.Characters.", StringComparison.OrdinalIgnoreCase) >= 0 &&
                            (n.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                             n.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                             n.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                             n.EndsWith(".svg", StringComparison.OrdinalIgnoreCase)))
                .OrderBy(n => n);

            foreach (var name in names)
            {
                var display = name.Split('.')[^2];
                AllImages.Add(new ImageItem { ResourceId = name, DisplayName = display });
            }
        }
        catch
        {
            // ha embedded resource helyett MauiAsset-et használsz,
            // akkor ide átalakítás kell: FileSystem.OpenAppPackageFileAsync("Resources/Images/xxx.png")
        }
    }

    private void ApplyFilter()
    {
        var q = (SearchText ?? String.Empty).Trim();
        var filtered = string.IsNullOrEmpty(q)
            ? AllImages
            : new ObservableCollection<ImageItem>(AllImages.Where(i => i.DisplayName.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0));

        FilteredImages.Clear();
        foreach (var it in filtered) FilteredImages.Add(it);
        OnPropertyChanged(nameof(FilteredImages));
    }

    private async void Preview(ImageItem item)
    {
        if (item == null) return;

        try
        {
            var page = new Views.ImagePreviewPage(item);
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }
        catch
        {
            // ignore navigation errors
        }
    }

    private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
