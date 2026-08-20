using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Méregtelenítés (Sámán, Második Törvénykönyv p.110, Ráolvasások). Summoned spirits leech any
/// kind and strength of poison out of a touched person or animal; a pure chant (no Szellemtánc
/// needed) is enough, which is why it's so taxing on the shaman's own energy. Book duration is
/// "Végleges" (permanent); approximated here as a long but finite value, mirroring how Warlock's
/// NeutralizePoison handles the same book wording.
/// </summary>
public sealed class PoisonPurging : ISpell
{
    public string Name => "Poison purging";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 20;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
