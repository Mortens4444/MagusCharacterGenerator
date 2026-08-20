using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzhenger (Tűzvarázsló, Első Törvénykönyv p.275). A rolling cylinder of fire that crosses the
/// caster's zone, following the terrain rather than a chosen direction, burning whatever it
/// touches or rolls over. Fire-school damage bypasses magic resistance entirely per the rulebook
/// (p.267), hence Power is null.
/// </summary>
public sealed class FireCylinder : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire cylinder";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 6;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
