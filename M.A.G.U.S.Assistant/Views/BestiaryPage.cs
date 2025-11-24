using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.Bestiary;
using Mtf.Extensions;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Views;

internal partial class BestiaryPage : SearchListPage
{
    public BestiaryPage(SearchListViewModel viewModel)
        : base(viewModel,
            "Bestiary",
            "M.A.G.U.S.Bestiary".CreateInstancesFromNamespace<Creature>().OrderBy(r => Lng.Elem(r.Name)).Select(DisplayItem.FromCreature))
    {
    }
}