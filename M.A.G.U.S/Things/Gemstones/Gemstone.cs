using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public abstract class Gemstone
{
    public string ImageName => Name.ToLower().Replace(" ", "_");

    public virtual string Name { get; }

    public string Description { get; }

    public virtual Money Price => Money.Free;

    public Gemstone(string description)
    {
        Name = GetType().Name;
        Description = description;
    }
}