using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

internal partial class MagicalObjectsPage(SearchListViewModel viewModel)
    : SearchListPage(viewModel, false, "Magic items", PreloadService.Instance.MagicalObjects.Select(DisplayItem.FromObject))
{
}