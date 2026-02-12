namespace M.A.G.U.S.GameSystem.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class DefenseHelperAttribute(int defenseValue) : Attribute
{
    public int DefenseValue { get; } = defenseValue;
}
