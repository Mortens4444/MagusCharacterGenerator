using MAGUS.Assistant.Models;
using MAGUS.Assistant.Services;
using MAGUS.Assistant.ViewModels;

namespace MAGUS.Assistant.Views;

internal sealed partial class MagicalObjectsPage(SearchListViewModel viewModel)
    : SearchListPage(viewModel, false, "Magic items", PreloadService.Instance.MagicalObjects.Select(DisplayItem.FromObject))
{
}