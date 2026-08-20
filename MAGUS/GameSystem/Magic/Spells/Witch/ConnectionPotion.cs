using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Kapcsolat főzete (Boszorkány — Bájitalok, Első Törvénykönyv p.234). Not drunk — a sympathetic-
/// magic tool requiring the target's hair/nail clippings, hence Power is null. For 1 hour (360
/// rounds) after the witch dips a finger in it, all their spell empowerment against that target
/// is doubled; the empowerment-doubling mechanic isn't modeled here, this is a flavor-only
/// catalog entry.
/// </summary>
public sealed class ConnectionPotion : ISpell
{
    public string Name => "Connection potion";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 45;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3600;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
