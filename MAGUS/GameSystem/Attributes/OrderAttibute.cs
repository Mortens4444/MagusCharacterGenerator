namespace MAGUS.GameSystem.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class OrderAttibute(int number) : Attribute
{
    public int Number { get; init; } = number;
}
