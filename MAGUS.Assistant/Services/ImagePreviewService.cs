using CommunityToolkit.Mvvm.Messaging;
using MAGUS.Assistant.Models;
using MAGUS.Assistant.Views;
using Mtf.Maui.Controls.Messages;

namespace MAGUS.Assistant.Services;

internal static class ImagePreviewService
{
    public static async Task ShowAsync(ImageItem? item)
    {
        if (item == null)
        {
            return;
        }

        try
        {
            var page = new ImagePreviewPage(item);
            await ShellNavigationService.ShowPageAsync(page).ConfigureAwait(true);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    public static Task ShowAsync(string? imageResourceId)
    {
        if (String.IsNullOrEmpty(imageResourceId))
        {
            return Task.CompletedTask;
        }

        return ShowAsync(new ImageItem
        {
            ResourceId = imageResourceId
        });
    }
}
