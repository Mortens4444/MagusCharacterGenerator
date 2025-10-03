using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.GameSystem.Runes;

namespace M.A.G.U.S.Assistant.Views;

public class RunesPage : SearchListPage
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