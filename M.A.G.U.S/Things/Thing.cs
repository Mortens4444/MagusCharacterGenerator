using M.A.G.U.S.Extensions;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;
using Mtf.Extensions.Services;

namespace M.A.G.U.S.Things;

public abstract class Thing : IHaveImage
{

    public string Id { get; set; } = Guid.NewGuid().ToString();

    public virtual string Name => GetType().Name;

    public virtual string[] Images => [$"{Name.ToImageName()}.png"];

    public virtual string DefaultImage => Images.Length > 0 ? Images[0] : String.Empty;

    public virtual string RandomImage => Images.Length > 1 ? Images[RandomProvider.GetSecureRandomInt(0, Images.Length)] : DefaultImage;

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
