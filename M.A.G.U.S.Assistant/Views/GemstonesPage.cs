using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Things.Gemstones;
using Mtf.Extensions;

namespace M.A.G.U.S.Assistant.Views;

internal partial class GemstonesPage : SearchListPage
{
    public GemstonesPage()
        : base("Gemstones",
            "M.A.G.U.S.Things.Gemstones"
                .CreateInstancesFromNamespace<Gemstone>()
                .OrderBy(r => r.Name)
                .Select(r => DisplayItem.FromGemstone(r)))
    {
    }
}