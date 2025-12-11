using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.Things.MagicalObjects;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

internal partial class MagicalObjectsPage : SearchListPage
{
    public MagicalObjectsPage(SearchListViewModel viewModel)
        : base(viewModel, false, "Magic items",
            "M.A.G.U.S.Things.MagicalObjects".CreateInstancesFromNamespace<MagicalObject>().OrderBy(r => Lng.Elem(r.Name)).Select(DisplayItem.FromObject))
    {
    }
}