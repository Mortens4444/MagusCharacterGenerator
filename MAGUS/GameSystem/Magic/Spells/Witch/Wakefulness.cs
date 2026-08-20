using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Éberség (Boszorkány — Lélekvarázs, Első Törvénykönyv p.219). Dual Asztrális+Mentális
/// resistance in the book, Astral modeled here. Grants 48 hours (17280 rounds) without needing
/// sleep; each renewal costs progressively more, not modeled.
/// </summary>
public sealed class Wakefulness : ISpell
{
    public string Name => "Wakefulness";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 1;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 17280;

    public int GetDamage() => 0;
}
