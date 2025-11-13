using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Utils;
using Mtf.LanguageService;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class ImagesViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<ImageItem> AllImages { get; } = [];
    public ObservableCollection<ImageItem> FilteredImages { get; } = [];

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

    private ImageItem? selectedImage;
    public ImageItem? SelectedImage
    {
        get => selectedImage;
        set
        {
            if (selectedImage == value)
            {
                return;
            }

            selectedImage = value;
            OnPropertyChanged(nameof(SelectedImage));
            if (selectedImage != null)
            {
                _ = PreviewAsync(selectedImage);
            }
        }
    }

    public ICommand PreviewCommand { get; }

    public ImagesViewModel()
    {
        PreviewCommand = new Command<ImageItem>(item => _ = PreviewAsync(item));
        LoadImages();
        ApplyFilter();
    }

    private void LoadImages()
    {
        try
        {
            var asm = Assembly.GetExecutingAssembly();
            var names = asm.GetManifestResourceNames()
                .Where(n => (n.Contains(".Resources.Images.Bestiary.", StringComparison.OrdinalIgnoreCase) ||
                            n.Contains(".Resources.Images.Characters.", StringComparison.OrdinalIgnoreCase)) &&
                            (n.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                             n.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                             n.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                             n.EndsWith(".svg", StringComparison.OrdinalIgnoreCase)))
                .OrderBy(n => n);

            foreach (var name in names)
            {
                var display = name.Split('.')[^2];
                AllImages.Add(new ImageItem { ResourceId = name, DisplayName = Lng.Elem(display.ToName()) });
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Load images error: {ex}");
        }
    }

    private void ApplyFilter()
    {
        var q = (SearchText ?? String.Empty).Trim();
        var filtered = (String.IsNullOrEmpty(q) ? AllImages : new ObservableCollection<ImageItem>(AllImages.Where(i => i.DisplayName.Contains(q, StringComparison.OrdinalIgnoreCase))))
            .OrderBy(comparer => comparer.DisplayName);

        FilteredImages.Clear();
        foreach (var it in filtered)
        {
            FilteredImages.Add(it);
        }

        OnPropertyChanged(nameof(FilteredImages));
    }

    private static async Task PreviewAsync(ImageItem item)
    {
        if (item == null)
        {
            return;
        }

        try
        {
            var page = new Views.ImagePreviewPage(item);
            var windows = Application.Current?.Windows;
            var mainPage = (windows != null && windows.Count > 0) ? windows[0].Page : null;
            if (mainPage?.Navigation != null)
            {
                await mainPage.Navigation.PushModalAsync(page).ConfigureAwait(true);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Preview error: {ex}");
        }
    }

    private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
