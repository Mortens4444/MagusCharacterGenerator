using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Betegségelhárítás (Sámán, Második Törvénykönyv p.110, Ráolvasások). Cures natural disease,
/// magical rontás, physical disabilities and other bodily damage: begins with an Áldozat
/// (sacrifice), then a deep, barely-audible chant while the shaman's open palm circles a hand's
/// width above the afflicted body part(s). Book cost is 3 Mp + 1 FP + Speciális (a severity-scaled
/// table of extra Mp/FP/duration by disease severity) and 23 perc + Speciális casting; the flat
/// baseline figures are used here, the severity table left unmodeled. This codebase has no
/// disease-progression simulation (severity stages, day/hour timelines); this class exists only as
/// a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class AfflictionCure : ISpell
{
    public string Name => "Affliction cure";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 3;

    public int PainTolerancePointCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1380;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
