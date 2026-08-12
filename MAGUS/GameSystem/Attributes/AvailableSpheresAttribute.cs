using MAGUS.Enums;

namespace MAGUS.GameSystem.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class AvailableSpheresAttribute(params Sphere[] spheres) : Attribute
{
    public Sphere[] Spheres { get; init; } = spheres;
}
