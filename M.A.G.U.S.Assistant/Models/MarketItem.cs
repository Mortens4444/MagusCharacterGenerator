using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Models;

public class MarketItem
{
    public MarketItem(Thing thing)
    {
        Name = Lng.Elem(thing.Name);
        Description = thing.Description ?? String.Empty;
        PriceString = thing.Price.ToTranslatedString();
        ImageName = thing.ImageName;
    }

    public string Name { get; set; } = String.Empty;
    public string ImageName { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public Money Price { get; set; } = Money.Free;
    public string PriceString { get; set; } = String.Empty;
}
