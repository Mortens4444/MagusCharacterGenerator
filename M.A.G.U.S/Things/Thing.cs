using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Things;

public abstract class Thing : ImageOwner
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public virtual Money Price => new(1);

    public double PriceMultiplier { get; set; } = 1;

    public virtual Money MultipliedPrice => Price * PriceMultiplier;

    public virtual string Description => "";

    /// <summary>
    /// Weight in kilograms.
    /// Use double for performance; switch to decimal if you need exact decimal arithmetic.
    /// </summary>
    public virtual double Weight { get; protected set; } = 0.0;
}
