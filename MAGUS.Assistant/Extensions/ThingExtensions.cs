using MAGUS.Things;

namespace MAGUS.Assistant.Extensions;

internal static class ThingExtensions
{
    public static bool IsFood(this Thing thing) => thing.GetType().Namespace == "MAGUS.Things.Food";
}
