using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things;
using Mtf.LanguageService.MAUI;
using Mtf.Maui.Controls.Extensions;

namespace M.A.G.U.S.Assistant.Models;

internal class MarketItem(Thing thing)
{
    public string Name { get; set; } = Lng.Elem(thing.Name);
    public string ImageName { get; set; } = thing.ImageName;
    public string Description { get; set; } = thing.Description;
    public Money Price { get; set; } = Money.Free;
    public string PriceString { get; set; } = thing.Price.ToTranslatedString();
}
