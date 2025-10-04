using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.GameSystem.PoisonsAndIllnesses;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Views;

public class PoisonsPage : SearchListPage
{
    public PoisonsPage()
        : base("Poisons",
            "M.A.G.U.S.GameSystem.Poisons"
                .CreateInstancesFromNamespace<Poison>()
                .OrderBy(r => Lng.Elem(r.Name))
                .Select(r => DisplayItem.FromPoison(r)))
    {
    }
}