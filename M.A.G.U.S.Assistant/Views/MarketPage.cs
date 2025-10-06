using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Things;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Views;

public class MarketPage : SearchListPage
{
    public MarketPage()
        : base("Market",
            "M.A.G.U.S.Things"
                .CreateInstancesFromNamespace<Thing>()
                .OrderBy(r => Lng.Elem(r.Name))
                .Select(r => DisplayItem.FromThing(r)))
    {
    }
}