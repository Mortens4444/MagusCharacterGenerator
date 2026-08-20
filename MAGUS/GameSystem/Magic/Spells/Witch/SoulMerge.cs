using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Eggyé válás (Boszorkány — Familiáris Mágia, Első Törvénykönyv p.232). Dual
/// Asztrális+Mentális resistance in the book, Astral modeled here. Splits the witch's soul into a
/// second animal body, sharing senses/Psi-use/Fp between both; approximated duration. The
/// elaborate two-body soul-sharing mechanic (shared Fp, separate Ép, ability to keep acting
/// through either body) is far beyond ISpell's model; this is a flavor-only catalog entry.
/// </summary>
public sealed class SoulMerge : ISpell
{
    public string Name => "Soul merge";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 1;

    public int ManaCost => 15;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
