using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things;

public abstract class Thing
{
    public virtual string Name => GetType().Name;

    public string ImageName => $"{Name.ToLower().Replace(" ", "_").Replace(",", String.Empty)}.png";

    public virtual Money Price => new(1);

    public double PriceMultiplier { get; set; } = 1;

    public virtual Money MultipliedPrice => Price * PriceMultiplier;

    public virtual string Description { get; protected set; } = "";

    /// <summary>
    /// Weight in kilograms.
    /// Use double for performance; switch to decimal if you need exact decimal arithmetic.
    /// </summary>
    public virtual double Weight { get; protected set; } = 0.0;
}
