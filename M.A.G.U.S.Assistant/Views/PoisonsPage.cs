using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

internal partial class PoisonsPage(SearchListViewModel viewModel)
    : SearchListPage(viewModel, false, "Poisons", PreloadService.Instance.Poisons.Select(DisplayItem.FromObject))
{
}