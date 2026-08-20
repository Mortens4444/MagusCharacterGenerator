namespace MAGUS.GameSystem.Magic.ElementalMagic;

/// <summary>
/// The result of casting one of the six element-creation mosaics: a quantity of primal
/// element, para-element, or raw Elemental Force at a given Strength (E), ready to be
/// shaped by a <see cref="Forms.IMosaicForm"/>. Source: p. 292-297.
/// </summary>
public sealed record CreatedElement
{
    public required int Strength { get; init; }

    public OsElementType? OsElement { get; init; }

    public ParaElementType? ParaElement { get; init; }

    public bool IsElementalForce { get; init; }

    /// <summary>Damage in Sp, where applicable (primal elements only among the creation mosaics roll damage directly).</summary>
    public int Damage { get; init; }
}
