using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Models;

internal class MarketItem(Thing thing)
{
    public string Name { get; set; } = Lng.Elem(thing.Name);
    public string ImageName { get; set; } = thing.ImageName ?? String.Empty;
    public string Description { get; set; } = thing.Description ?? String.Empty;
    public Money Price { get; set; } = Money.Free;
    public string PriceString { get; set; } = thing.Price.ToTranslatedString();
}
