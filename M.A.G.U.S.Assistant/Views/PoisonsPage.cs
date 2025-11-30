using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.GameSystem.PoisonsAndIllnesses;
using Mtf.Extensions;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Views;

internal partial class PoisonsPage : SearchListPage
{
    public PoisonsPage(SearchListViewModel viewModel)
        : base(viewModel, false, "Poisons",
            "M.A.G.U.S.GameSystem.Poisons".CreateInstancesFromNamespace<Poison>().OrderBy(r => Lng.Elem(r.Name)).Select(DisplayItem.FromObject))
    {
    }
}