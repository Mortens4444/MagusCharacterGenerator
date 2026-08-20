using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Csapdakeresés (Boszorkány — Misztikus képesség, Első Törvénykönyv p.204). Book offers three
/// tiers (8/14/20 Mana-pont) detecting progressively more (mundane traps / +magical+dwarf-made
/// traps / +future dangers); only the cheapest tier's cost is shown. Duration is per caster level
/// in minutes, level-1 baseline, not level-scaled.
/// </summary>
public sealed class TrapSensing : ISpell
{
    public string Name => "Trap sensing";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
