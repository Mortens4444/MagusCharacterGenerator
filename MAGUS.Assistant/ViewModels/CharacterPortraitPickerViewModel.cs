using CommunityToolkit.Mvvm.Input;
using MAGUS.Assistant.Models;
using MAGUS.Assistant.Services;
using System.Collections.ObjectModel;

namespace MAGUS.Assistant.ViewModels;

internal sealed partial class CharacterPortraitPickerViewModel : BaseViewModel
{
    private string searchText = String.Empty;
    private ObservableCollection<ImageItem> selectedImages;

    public event Action<IReadOnlyList<string>>? Confirmed;
    public event Action? Cancelled;

    public ObservableCollection<ImageItem> FilteredImages { get; } = [];

    public CharacterPortraitPickerViewModel(IEnumerable<string> currentResourceIds)
    {
        var currentIds = new HashSet<string>(currentResourceIds);
        selectedImages = [.. PreloadService.Instance.CachedImageItems.Where(i => currentIds.Contains(i.ResourceId))];

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

    public ObservableCollection<ImageItem> SelectedImages
    {
        get => selectedImages;
        set => SetProperty(ref selectedImages, value);
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
        Confirmed?.Invoke([.. SelectedImages.Select(i => i.ResourceId)]);
    }

    [RelayCommand]
    private void Cancel()
    {
        Cancelled?.Invoke();
    }
}
