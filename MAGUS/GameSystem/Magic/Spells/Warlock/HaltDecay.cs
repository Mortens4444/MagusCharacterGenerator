using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Bomlás megfékezése (Boszorkánymester — Nekromancia, Első Törvénykönyv p.262-263). Duration is
/// k6+szint nap in the book; a 1-day (level-1) baseline shown, not level-scaled. Preserves a
/// corpse from decay; pure utility.
/// </summary>
public sealed class HaltDecay : ISpell
{
    public string Name => "Halt decay";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 10;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
