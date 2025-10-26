using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Bestiary;
using Mtf.Extensions;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Views;

internal partial class BestiaryPage : SearchListPage
{
    public BestiaryPage()
        : base("Bestiary",
            "M.A.G.U.S.Bestiary"
                .CreateInstancesFromNamespace< Creature> ()
                .OrderBy(r => Lng.Elem(r.Name))
                .Select(r => DisplayItem.FromCreature(r)))
    {
    }
}