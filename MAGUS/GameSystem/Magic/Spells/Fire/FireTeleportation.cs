using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűz teleportálása (Tűzvarázsló, Első Törvénykönyv p.272). Teleports an entire primal fire to
/// another point within the caster's zone; only the whole fire can be moved, not part of it.
/// Fire-school damage bypasses magic resistance entirely per the rulebook (p.267), hence Power
/// is null.
/// </summary>
public sealed class FireTeleportation : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire teleportation";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
