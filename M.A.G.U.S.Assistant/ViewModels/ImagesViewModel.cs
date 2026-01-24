using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Interfaces;
using Mtf.LanguageService.MAUI;
using Mtf.Maui.Controls.Messages;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class ImagesViewModel : BaseViewModel
{
    private string searchText = String.Empty;
    private static List<ImageItem>? cachedImageItems;

    public ImagesViewModel()
    {
        PreviewCommand = new Command<ImageItem>(item => _ = PreviewAsync(item));
        LoadImagesFromTypes();
        ApplyFilter();
    }

    public ObservableCollection<ImageItem> AllImages { get; } = [];
    public ObservableCollection<ImageItem> FilteredImages { get; } = [];

    public string SearchText
    {
        get => searchText;
        set
        {
            if (searchText == value)
            {
                return;
            }

            searchText = value;
            OnPropertyChanged();
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
            OnPropertyChanged();
            if (selectedImage != null)
            {
                _ = PreviewAsync(selectedImage);
            }
        }
    }

    public ICommand PreviewCommand { get; }

    private void LoadImagesFromTypes()
    {
        // Ha már egyszer megcsináltuk, nem dolgozunk feleslegesen
        if (cachedImageItems == null)
        {
            cachedImageItems = new List<ImageItem>();
            BuildImageCache();
        }

        // A UI kollekció feltöltése a cache-ből
        AllImages.Clear();
        foreach (var item in cachedImageItems)
        {
            AllImages.Add(item);
        }
    }

    private void BuildImageCache()
    {
        try
        {
            var interfaceType = typeof(IHaveImage);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => interfaceType.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);

            foreach (var type in types)
            {
                try
                {
                    var instance = Activator.CreateInstance(type);
                    var nameProperty = type.GetProperty("Name");
                    var displayNameProperty = type.GetProperty("DisplayName");

                    if (instance is IHaveImage imageProvider)
                    {
                        if (imageProvider.Images != null)
                        {
                            foreach (var image in imageProvider.Images)
                            {
                                if (String.IsNullOrWhiteSpace(image))
                                {
                                    continue;
                                }

                                var entityName = nameProperty?.GetValue(instance)?.ToString() ?? displayNameProperty?.GetValue(instance)?.ToString();
                                if (String.IsNullOrWhiteSpace(entityName))
                                {
                                    continue;
                                }

                                cachedImageItems.Add(new ImageItem
                                {
                                    ResourceId = image.Trim(),
                                    DisplayName = Lng.Elem(entityName)
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Skipping type {type.Name}: {ex.Message}");
                }
            }

            cachedImageItems = [.. cachedImageItems?.OrderBy(x => Lng.Elem(x.DisplayName))];
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage($"Error building image cache: {ex.Message}"));
        }
    }

    private void ApplyFilter()
    {
        var filtered = (String.IsNullOrEmpty(SearchText) ? AllImages :
            new ObservableCollection<ImageItem>(AllImages.Where(i => i.DisplayName.Contains(SearchText, StringComparison.OrdinalIgnoreCase))))
            .OrderBy(comparer => comparer.DisplayName);

        FilteredImages.Clear();
        foreach (var it in filtered)
        {
            FilteredImages.Add(it);
        }

        OnPropertyChanged(nameof(FilteredImages));
    }

    private static Task PreviewAsync(ImageItem item)
    {
        return ImagePreviewService.ShowAsync(item);
    }
}
