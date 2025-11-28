using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Things;
using Mtf.Extensions;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Views;

internal partial class MarketPage : SearchListPage
{
    public MarketPage(SearchListViewModel viewModel)
        : base(viewModel,
            "Market",
            "M.A.G.U.S.Things".CreateInstancesFromNamespace<Thing>().OrderBy(r => Lng.Elem(r.Name)).Select(r => DisplayItem.FromThing(r, null)))
    {
    }

    public MarketPage(SearchListViewModel viewModel, Character character)
        : base(viewModel,
            $"{Lng.Elem("Market")} - {character.Name}",
            "M.A.G.U.S.Things"
                .CreateInstancesFromNamespace<Thing>()
                .OrderBy(r => Lng.Elem(r.Name))
                .Select(r => DisplayItem.FromThing(r, character)))
    {
        viewModel.Character = character;
    }
}