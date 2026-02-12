using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

internal partial class RunesPage(SearchListViewModel viewModel) :
    SearchListPage(viewModel, false, "Runes", PreloadService.Instance.Runes.Select(DisplayItem.FromObject))
{
}