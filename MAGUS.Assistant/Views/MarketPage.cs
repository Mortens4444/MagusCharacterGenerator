using MAGUS.Assistant;
using MAGUS.Assistant.Models;
using MAGUS.Assistant.Services;
using MAGUS.Assistant.ViewModels;
using MAGUS.GameSystem;
using Mtf.LanguageService;

namespace MAGUS.Assistant.Views;

internal sealed partial class MarketPage : SearchListPage
{
    public MarketPage(SearchListViewModel viewModel)
        : base(viewModel, true, "Market", PreloadService.Instance.Things.Select(DisplayItem.FromObject))
    {
        ApplyActiveMarketEvent(viewModel);
    }

    public MarketPage(SearchListViewModel viewModel, Character character)
        : base(viewModel, true, $"{Lng.Elem("Market")} - {character.Name}",
            PreloadService.Instance.Things.Select(r => DisplayItem.FromObject(r, character)))
    {
        viewModel.Character = character;
        viewModel.ShowOnlyAffordable = true;
        ApplyActiveMarketEvent(viewModel);
    }

    // LoadItems (called from the SearchListPage base constructor above) resets every Thing's
    // PriceMultiplier back to the view model's own default of 1.0, which would silently cancel
    // an active background sale/inflation event. Re-apply it now that the base ctor has run.
    private static void ApplyActiveMarketEvent(SearchListViewModel viewModel)
    {
        var settingsService = MauiProgram.Services.GetRequiredService<SettingsService>();
        viewModel.PriceMultiplier = settingsService.ActiveMarketPriceMultiplier;
    }
}