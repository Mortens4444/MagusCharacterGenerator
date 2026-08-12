using MAGUS.Assistant.Models;
using MAGUS.Assistant.Services;
using MAGUS.Assistant.ViewModels;

namespace MAGUS.Assistant.Views;

internal sealed partial class GemstonesPage(SearchListViewModel viewModel)
    : SearchListPage(viewModel, false, "Gemstones", PreloadService.Instance.Gemstones.Select(DisplayItem.FromObject))
{
}