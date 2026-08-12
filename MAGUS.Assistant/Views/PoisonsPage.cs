using MAGUS.Assistant.Models;
using MAGUS.Assistant.Services;
using MAGUS.Assistant.ViewModels;

namespace MAGUS.Assistant.Views;

internal sealed partial class PoisonsPage(SearchListViewModel viewModel)
    : SearchListPage(viewModel, false, "Poisons", PreloadService.Instance.Poisons.Select(DisplayItem.FromObject))
{
}