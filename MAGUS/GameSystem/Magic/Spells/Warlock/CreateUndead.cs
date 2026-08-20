using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Élőholt teremtés (Boszorkánymester — Nekromancia, Első Törvénykönyv p.259). Breathes mindless
/// animating energy into a corpse (a zombie), giving it 1 Ép and a single one-sentence command it
/// will mindlessly pursue forever. Book duration is "maradandó" (permanent); approximated as a
/// long but finite value. This codebase has no controllable-undead-minion or creature-summoning
/// system; this class exists only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class CreateUndead : ISpell
{
    public string Name => "Create undead";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 22;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
