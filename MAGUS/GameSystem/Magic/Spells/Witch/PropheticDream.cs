using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Jósálom (Boszorkány — Lélekvarázs / Álomellenőrző varázslatok, Első Törvénykönyv p.219). Book
/// resistance is specifically "tudatalatti asztrál ME" (subconscious astral only); modeled as
/// ordinary Astral resistance. Self-only; lets the witch dream about a chosen topic for insight,
/// lasting 6 hours (2160 rounds).
/// </summary>
public sealed class PropheticDream : ISpell
{
    public string Name => "Prophetic dream";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 10;

    public int ManaCost => 10;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 300;

    public int DurationInRounds => 2160;

    public int GetDamage() => 0;
}
