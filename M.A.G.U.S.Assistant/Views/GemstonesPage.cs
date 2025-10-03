using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.GameSystem.Gemstones;

namespace M.A.G.U.S.Assistant.Views;

public class GemstonesPage : SearchListPage
{
    public GemstonesPage()
        : base("Gemstones",
            "M.A.G.U.S.GameSystem.Gemstones"
                .CreateInstancesFromNamespace<Gemstone>()
                .OrderBy(r => r.Name)
                .Select(r => DisplayItem.FromGemstone(r)))
    {
    }
}