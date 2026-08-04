using M.A.G.U.S.Things;

namespace M.A.G.U.S.Assistant.Extensions;

internal static class ThingExtensions
{
    public static bool IsFood(this Thing thing) => thing.GetType().Namespace == "M.A.G.U.S.Things.Food";
}
