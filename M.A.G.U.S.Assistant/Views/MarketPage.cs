using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Things;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

internal partial class MarketPage : SearchListPage
{
    public MarketPage(SearchListViewModel viewModel)
        : base(viewModel, true, "Market",
            "M.A.G.U.S.Things".CreateInstancesFromNamespace<Thing>(typeof(INotForSale)).OrderBy(r => Lng.Elem(r.Name)).Select(DisplayItem.FromObject))
    {
    }

    public MarketPage(SearchListViewModel viewModel, Character character)
        : base(viewModel, true, $"{Lng.Elem("Market")} - {character.Name}",
            "M.A.G.U.S.Things".CreateInstancesFromNamespace<Thing>(typeof(INotForSale)).OrderBy(r => Lng.Elem(r.Name)).Select(r => DisplayItem.FromObject(r, character)))
    {
        viewModel.Character = character;
        viewModel.ShowOnlyAffordable = true;
    }
}