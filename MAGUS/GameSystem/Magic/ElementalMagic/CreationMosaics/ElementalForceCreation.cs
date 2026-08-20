namespace MAGUS.GameSystem.Magic.ElementalMagic.CreationMosaics;

/// <summary>
/// Elemi Erő Teremtése (p. 294-295). Creates raw Elemental Force at 1 Mp per E; 1E holds 5 kg
/// stationary, or an equivalently smaller real weight the faster that weight is moving
/// (effective weight = real weight × speed multiplier, capped at 5 kg per E).
/// </summary>
public sealed class ElementalForceCreation : IElementCreationMosaic
{
    public string Name => "Elemental Force Creation";

    public int CastingTimeInSegments => 1;

    public int GetManaCost(int strength) => Validate(strength);

    public CreatedElement Create(int strength)
    {
        Validate(strength);
        return new CreatedElement { IsElementalForce = true, Strength = strength };
    }

    /// <summary>Maximum real-world weight (kg) that Strength E of Elemental Force can hold at the given speed.</summary>
    public double GetMaxHeldWeightKg(int strength, ObjectSpeed speed) => Validate(strength) * 5.0 / GetSpeedMultiplier(speed);

    private static double GetSpeedMultiplier(ObjectSpeed speed) => speed switch
    {
        ObjectSpeed.Stationary => 1,
        ObjectSpeed.Walking => 2,
        ObjectSpeed.Running => 5,
        ObjectSpeed.Galloping => 10,
        _ => throw new ArgumentOutOfRangeException(nameof(speed))
    };

    private static int Validate(int strength) =>
        strength > 0 ? strength : throw new ArgumentOutOfRangeException(nameof(strength), "Strength (E) must be at least 1.");
}

public enum ObjectSpeed
{
    Stationary,
    Walking,
    Running,
    Galloping
}
