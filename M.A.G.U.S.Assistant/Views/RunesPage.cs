using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.GameSystem.Runes;
using Mtf.Extensions;

namespace M.A.G.U.S.Assistant.Views;

internal partial class RunesPage : SearchListPage
{
    public RunesPage(SearchListViewModel viewModel)
        : base(viewModel,
            "Runes",
            "M.A.G.U.S.GameSystem.Runes".CreateInstancesFromNamespace<Rune>().OrderBy(r => r.Name).Select(DisplayItem.FromRune))
    {
    }
}