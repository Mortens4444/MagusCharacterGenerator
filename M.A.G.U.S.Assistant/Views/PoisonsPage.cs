using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

namespace M.A.G.U.S.Assistant.Views;

public class PoisonsPage : SearchListPage
{
    public PoisonsPage()
        : base("Poisons",
            "M.A.G.U.S.GameSystem.Poisons"
                .CreateInstancesFromNamespace<Poison>()
                .OrderBy(r => r.Name)
                .Select(r => DisplayItem.FromPoison(r)))
    {
    }
}