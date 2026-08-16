using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using System.Reflection;

namespace MAGUS.Extensions;

public static class DeityExtensions
{
    public static Sphere[] GetAvailableSpheres(this Deity deity)
    {
        var field = typeof(Deity).GetField(deity.ToString());
        var attribute = field?.GetCustomAttribute<AvailableSpheresAttribute>();
        return attribute?.Spheres ?? [];
    }
}
