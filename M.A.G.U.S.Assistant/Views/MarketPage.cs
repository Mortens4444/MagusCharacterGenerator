using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.GameSystem;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

internal partial class MarketPage : SearchListPage
{
    public MarketPage(SearchListViewModel viewModel)
        : base(viewModel, true, "Market", PreloadService.Instance.Things.Select(DisplayItem.FromObject))
    {
    }

    public MarketPage(SearchListViewModel viewModel, Character character)
        : base(viewModel, true, $"{Lng.Elem("Market")} - {character.Name}",
            PreloadService.Instance.Things.Select(r => DisplayItem.FromObject(r, character)))
    {
        viewModel.Character = character;
        viewModel.ShowOnlyAffordable = true;
    }
}