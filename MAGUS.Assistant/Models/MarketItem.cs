using MAGUS.Assistant.Extensions;
using MAGUS.GameSystem.Valuables;
using MAGUS.Things;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Extensions;

namespace MAGUS.Assistant.Models;

internal sealed class MarketItem(Thing thing)
{
    public string Name { get; set; } = Lng.Elem(thing.Name);
    public string DefaultImage { get; set; } = thing.DefaultImage;
    public string Description { get; set; } = thing.Description;
    public Money Price { get; set; } = Money.Free;
    public string PriceString { get; set; } = thing.Price.ToTranslatedString();
}
