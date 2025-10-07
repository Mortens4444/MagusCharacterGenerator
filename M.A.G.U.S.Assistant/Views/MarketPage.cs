using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Things;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Views;

public class MarketPage : SearchListPage
{
    private readonly Character? character;

    public MarketPage()
        : base("Market",
            "M.A.G.U.S.Things"
                .CreateInstancesFromNamespace<Thing>()
                .OrderBy(r => Lng.Elem(r.Name))
                .Select(r => DisplayItem.FromThing(r)))
    {
        character = null;
    }

    public MarketPage(Character character)
                : base("Market",
            "M.A.G.U.S.Things"
                .CreateInstancesFromNamespace<Thing>()
                .OrderBy(r => Lng.Elem(r.Name))
                .Select(r => DisplayItem.FromThing(r)))
    {
        this.character = character;
    }
}