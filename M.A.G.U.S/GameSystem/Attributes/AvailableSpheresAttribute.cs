using M.A.G.U.S.Enums;

namespace M.A.G.U.S.GameSystem.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class AvailableSpheresAttribute(params Sphere[] spheres) : Attribute
{
    public Sphere[] Spheres { get; init; } = spheres;
}
