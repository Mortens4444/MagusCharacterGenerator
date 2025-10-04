using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.GameSystem.Gemstones;
using M.A.G.U.S.GameSystem.MagicalObjects;

namespace M.A.G.U.S.Assistant.Views;

public class MagicalObjectsPage : SearchListPage
{
    public MagicalObjectsPage()
        : base("Magic items",
            "M.A.G.U.S.GameSystem.MagicalObjects"
                .CreateInstancesFromNamespace<MagicalObject>()
                .OrderBy(r => r.Name)
                .Select(r => DisplayItem.FromMagicalObject(r)))
    {
    }
}