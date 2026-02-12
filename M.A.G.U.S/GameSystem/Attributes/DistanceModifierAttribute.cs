namespace M.A.G.U.S.GameSystem.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class DistanceModifierAttribute(double distanceModifier) : Attribute
{
    public int DistanceModifier { get; } = (int)Math.Round(distanceModifier);
}
