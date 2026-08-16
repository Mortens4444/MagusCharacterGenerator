using CommunityToolkit.Mvvm.Input;
using MAGUS.Assistant.Models;
using MAGUS.Assistant.Services;
using Mtf.LanguageService;
using System.Collections.ObjectModel;

namespace MAGUS.Assistant.ViewModels;

internal sealed partial class CharacterPortraitPickerViewModel : BaseViewModel
{
    private string searchText = String.Empty;
    private ImageItem? selectedImage;

    public event Action<IReadOnlyList<string>>? Confirmed;
    public event Action? Cancelled;

    public ObservableCollection<ImageItem> FilteredImages { get; } = [];

    public CharacterPortraitPickerViewModel(IEnumerable<string> currentResourceIds)
    {
        var currentId = currentResourceIds.FirstOrDefault();
        if (currentId != null)
        {
            selectedImage = PreloadService.Instance.CachedImageItems.FirstOrDefault(i => i.ResourceId == currentId)
                ?? new ImageItem { ResourceId = currentId, DisplayName = Lng.Elem("Custom image") };
        }

        ApplyFilter();
    }

    public string SearchText
    {
        get => searchText;
        set
        {
            if (SetProperty(ref searchText, value))
            {
                ApplyFilter();
            }
        }
    }

    public ImageItem? SelectedImage
    {
        get => selectedImage;
        set => SetProperty(ref selectedImage, value);
    }

    private void ApplyFilter()
    {
        var all = PreloadService.Instance.CachedImageItems;
        var filtered = String.IsNullOrWhiteSpace(SearchText)
            ? all
            : all.Where(i => i.DisplayName.Contains(SearchText, StringComparison.OrdinalIgnoreCase));

        FilteredImages.Clear();
        foreach (var item in filtered.OrderBy(i => i.DisplayName))
        {
            FilteredImages.Add(item);
        }
    }

    [RelayCommand]
    private void Confirm()
    {
        Confirmed?.Invoke(SelectedImage != null ? [SelectedImage.ResourceId] : []);
    }

    [RelayCommand]
    private void Cancel()
    {
        Cancelled?.Invoke();
    }
}
