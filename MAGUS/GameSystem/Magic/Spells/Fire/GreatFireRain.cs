using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzeső (Magasiskola) (Tűzvarázsló, Első Törvénykönyv p.281). The advanced, large-area sibling
/// of the basic Tűzeső (see FireRain.cs): a 1 km diameter zone rains fire, igniting flammables and
/// melting the ground itself. Book damage is TSZ/2 + 1D6 per round; the level-scaling TSZ/2 term
/// is omitted at this codebase's level-1 baseline convention (see ObjectTransformation.cs for the
/// same pattern), leaving a flat 1D6. Fire-school damage bypasses magic resistance entirely per
/// the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class GreatFireRain : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Great fire rain";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 35;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 240;

    public int DurationInRounds => 60;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
