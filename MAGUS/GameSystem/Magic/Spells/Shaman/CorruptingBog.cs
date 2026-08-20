using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Fertő (Sámán, Második Törvénykönyv p.111-112, Ráolvasások — Területre ható átkok). Similar to
/// Mocsár but slower: an expanding fungal-blight bog (Burjánhalál) that waterlogs the ground and
/// spreads 3 m/week in every direction, dissolving any plant or organic matter it reaches. Area is
/// 25 + caster level meters radius, level-1 baseline used (not level-scaled). Book duration is
/// "Maradandó" (lasting); approximated here as a long but finite value. This codebase has no
/// terrain-corruption/disease-spread subsystem; this class exists only as a spellbook/catalog
/// entry with no simulated mechanical effect.
/// </summary>
public sealed class CorruptingBog : ISpell
{
    public string Name => "Corrupting bog";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 70;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 540;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
