using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things;

public abstract class Thing
{
    public virtual string Name => GetType().Name;

    public string? ImageName => Name.ToLower();

    public virtual Money Price => Money.Free;

    public string? Description { get; set; }

    /// <summary>
    /// Weight in kilograms.
    /// Use double for performance; switch to decimal if you need exact decimal arithmetic.
    /// </summary>
    public virtual double Weight { get; protected set; } = 0.0;
}
