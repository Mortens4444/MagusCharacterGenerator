using MAGUS.GameSystem.Attributes;
using System.Reflection;

namespace MAGUS.Utils;

public static class DistanceModifierHelper
{
    public static int Get<TEnum>(TEnum value)
        where TEnum : Enum
    {
        var member = typeof(TEnum)
            .GetMember(value.ToString())
            .FirstOrDefault();

        return member?
            .GetCustomAttribute<DistanceModifierAttribute>()?
            .DistanceModifier ?? 0;
    }
}