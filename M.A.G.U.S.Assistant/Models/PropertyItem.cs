namespace M.A.G.U.S.Assistant.Models;

public class PropertyItem(string name, object value)
{
    public string Name { get; } = name;
    public object Value { get; } = value ?? String.Empty;

    public override string ToString() => $"{Name}: {Value}";
}
