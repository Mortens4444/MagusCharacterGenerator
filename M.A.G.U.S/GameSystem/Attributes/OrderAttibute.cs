namespace M.A.G.U.S.GameSystem.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class OrderAttibute(int number) : Attribute
{
    public int Number { get; init; } = number;
}
