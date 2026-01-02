using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.Things.Gemstones;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

internal partial class GemstonesPage : SearchListPage
{
    public GemstonesPage(SearchListViewModel viewModel)
        : base(viewModel, false, "Gemstones",
            "M.A.G.U.S.Things.Gemstones".CreateInstancesFromNamespace<Gemstone>().OrderBy(g => Lng.Elem(g.Name)).Select(DisplayItem.FromObject))
    {
    }
}