using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Óvás (Sámán, Második Törvénykönyv p.109-110). Cast through Szellemtánc around a herd of
/// livestock, this asks the spirits to ward the animals against evil curses: while it lasts the
/// herd grows calmer, breeds faster (up to double), and grows visibly healthier (plumper, better
/// milk and meat); the animals avoid natural disease, and an Átok/Rontás only takes hold on them
/// if its strength exceeds this spell's. Only ever targets animals, and cannot cure ones already
/// cursed/diseased. Scales heavily by Experience Level via a table (herd size, duration, casting
/// time): level-1 baseline used here is 20 animals, 1 week (60480 rounds) duration, 1 round + 5
/// minutes (310 segments) casting time; the full table is not modeled, so this is not
/// level-scaled. The book also lets the ward's strength be raised 4 E per 1 extra Mana point,
/// letting the shaman call stronger guardian spirits; this doesn't map onto PowerBonusPerManaPoint
/// since Power here is null (no magic-resistance roll against a target), so it is left unmodeled.
/// Mana cost is 6 Mp + 1 FP in the book; both are modeled (ManaCost/PainTolerancePointCost).
/// </summary>
public sealed class HerdWarding : ISpell
{
    public string Name => "Herd warding";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 6;

    public int PainTolerancePointCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 310;

    public int DurationInRounds => 60480;

    public int GetDamage() => 0;
}
