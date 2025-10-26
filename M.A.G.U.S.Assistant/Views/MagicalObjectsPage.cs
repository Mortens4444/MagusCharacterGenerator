using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Things.MagicalObjects;
using Mtf.Extensions;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Views;

internal partial class MagicalObjectsPage : SearchListPage
{
    public MagicalObjectsPage()
        : base("Magic items",
            "M.A.G.U.S.Things.MagicalObjects"
                .CreateInstancesFromNamespace<MagicalObject>()
                .OrderBy(r => Lng.Elem(r.Name))
                .Select(r => DisplayItem.FromMagicalObject(r)))
    {
    }
}