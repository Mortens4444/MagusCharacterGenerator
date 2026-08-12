namespace MAGUS.GameSystem.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class DefenseHelperAttribute(int defenseValue) : Attribute
{
    public int DefenseValue { get; } = defenseValue;
}
