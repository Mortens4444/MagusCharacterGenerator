using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.Bestiary;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

internal partial class BestiaryPage : SearchListPage
{
    public BestiaryPage(BestiaryViewModel viewModel)
        : base(viewModel, false, "Bestiary",
          "M.A.G.U.S.Bestiary".CreateInstancesFromNamespace<Creature>()
                              .OrderBy(r => Lng.Elem(r.Name))
                              .Select(DisplayItem.FromObject))
    {
        var randomToolbarItem = new ToolbarItem
        {
            //IconImageSource = "beast.png",
            Text = "🎲", //Lng.Elem("Random"),
            Order = ToolbarItemOrder.Primary,
            Priority = 0
        };

        randomToolbarItem.SetBinding(MenuItem.CommandProperty, nameof(BestiaryViewModel.PickRandomCommand));
        ToolbarItems.Add(randomToolbarItem);
    }
}