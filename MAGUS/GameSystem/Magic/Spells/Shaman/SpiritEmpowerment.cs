using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Felruházás (Sámán, Második Törvénykönyv p.109). Cast through Szellemtánc, this asks the
/// shaman's spirits for their goodwill, help and protection on the target (a creature, area, or
/// object reached by touch). For the spell's duration the target is immune to natural disease,
/// gets +3 to Health checks against Rontás curses, and its Astral/Mental magic resistance rises by
/// the spell's Erősség; curses only take hold if their own strength exceeds this spell's. Objects
/// count as magical for the duration (no dust, no fading, no rust). The shaman can empower as many
/// targets at once as their Experience Level, over an area scaling 3 m radius per level. Duration
/// is listed as Speciális but backed by a level/day table (1-5:1, 6-9:2, 10-13:3, 14-17:5, 17+:7
/// days); the level-1 baseline (1 day = 8640 rounds) is used here, table omitted, not
/// level-scaled. Mana cost is 7 Mp + 1 FP in the book; both are modeled (ManaCost/PainTolerancePointCost).
/// </summary>
public sealed class SpiritEmpowerment : ISpell
{
    public string Name => "Spirit empowerment";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 7;

    public int PainTolerancePointCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 40;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
