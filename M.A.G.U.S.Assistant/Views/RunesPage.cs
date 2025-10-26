using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.GameSystem.Runes;
using Mtf.Extensions;

namespace M.A.G.U.S.Assistant.Views;

internal partial class RunesPage : SearchListPage
{
    public RunesPage()
        : base("Runes",
            "M.A.G.U.S.GameSystem.Runes"
                .CreateInstancesFromNamespace<Rune>()
                .OrderBy(r => r.Name)
                .Select(r => DisplayItem.FromRune(r)))
    {
    }
}