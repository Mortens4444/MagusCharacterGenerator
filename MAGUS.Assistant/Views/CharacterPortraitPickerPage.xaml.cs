using MAGUS.Assistant.Models;
using MAGUS.Assistant.Services;
using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

internal sealed partial class CharacterPortraitPickerPage : NotifierPage
{
    private readonly TaskCompletionSource<IReadOnlyList<string>?> tcs = new();
    private readonly CharacterPortraitPickerViewModel viewModel;
    private bool isClosing;

    public CharacterPortraitPickerPage(CharacterPortraitPickerViewModel viewModel)
    {
        InitializeComponent();

        this.viewModel = viewModel;
        viewModel.Confirmed += OnConfirmed;
        viewModel.Cancelled += OnCancelled;
        BindingContext = viewModel;

        // CollectionView.SelectedItems TwoWay binding is unreliable for propagating
        // user taps back to the view model, so selection is tracked explicitly via
        // SelectionChanged instead. Pre-select the image the character already has,
        // if it's one of the gallery images (a custom upload won't be in the list).
        if (viewModel.SelectedImage != null && FilteredContains(viewModel.SelectedImage))
        {
            ImagesCollectionView.SelectedItem = viewModel.SelectedImage;
        }
    }

    public Task<IReadOnlyList<string>?> ResultTask => tcs.Task;

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Translator.Translate(this);
    }

    private bool FilteredContains(ImageItem item) => viewModel.FilteredImages.Any(i => i.ResourceId == item.ResourceId);

    private async void OnConfirmed(IReadOnlyList<string> resourceIds)
    {
        await CloseAsync(resourceIds).ConfigureAwait(true);
    }

    private async void OnCancelled()
    {
        await CloseAsync(null).ConfigureAwait(true);
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        viewModel.SelectedImage = e.CurrentSelection.OfType<ImageItem>().FirstOrDefault();
    }

    private async void PickCustomImageClicked(object sender, EventArgs e)
    {
        try
        {
            var picked = await MediaPicker.Default.PickPhotoAsync().ConfigureAwait(true);
            if (picked == null)
            {
                return;
            }

            var destDir = Path.Combine(FileSystem.AppDataDirectory, "CustomPortraits");
            Directory.CreateDirectory(destDir);
            var destPath = Path.Combine(destDir, $"{Guid.NewGuid()}{Path.GetExtension(picked.FileName)}");

            await using (var sourceStream = await picked.OpenReadAsync().ConfigureAwait(true))
            await using (var destStream = File.Create(destPath))
            {
                await sourceStream.CopyToAsync(destStream).ConfigureAwait(true);
            }

            // Custom uploads aren't part of the gallery, so clear any gallery selection
            // to keep the single-select state (grid vs. custom) unambiguous.
            ImagesCollectionView.SelectedItem = null;
            viewModel.SelectedImage = new ImageItem { ResourceId = destPath, DisplayName = Lng.Elem("Custom image") };
        }
        catch (Exception ex)
        {
            await ShellNavigationService.DisplayAlertAsync(ex.Message).ConfigureAwait(true);
        }
    }

    private async Task CloseAsync(IReadOnlyList<string>? result)
    {
        if (isClosing)
        {
            return;
        }

        isClosing = true;
        await ShellNavigationService.CloseModalPageAsync().ConfigureAwait(true);
        tcs.TrySetResult(result);
    }
}
