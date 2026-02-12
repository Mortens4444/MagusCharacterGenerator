using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

internal partial class GemstonesPage(SearchListViewModel viewModel)
    : SearchListPage(viewModel, false, "Gemstones", PreloadService.Instance.Gemstones.Select(DisplayItem.FromObject))
{
}