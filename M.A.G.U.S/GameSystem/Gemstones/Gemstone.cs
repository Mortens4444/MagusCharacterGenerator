namespace M.A.G.U.S.GameSystem.Gemstones;

public abstract class Gemstone
{
    public string ImageName => Name.ToLower().Replace(" ", "_");
    public virtual string Name { get; }
    public string Description { get; }

    public Gemstone(string description)
    {
        Name = GetType().Name;
        Description = description;
    }
}