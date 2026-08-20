using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// (Unnamed in the scanned source — the Érzelemkioltó spell immediately following Düh kioltása on
/// p.211, "Mana-pont: 15 Erősség: 7"; reconstructed name "Love suppression" from its description.)
/// (Boszorkány — Asztrálmágia, Első Törvénykönyv p.211). Extinguishes even the strongest love the
/// target feels toward one chosen person, leaving indifference rather than hatred. Duration is
/// level-difference-based (1 day per level the caster exceeds the target, else 1 hour) in the
/// book; approximated here as a flat 1-hour (360-round) duration.
/// </summary>
public sealed class LoveSuppression : ISpell
{
    public string Name => "Love suppression";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 7;

    public int ManaCost => 15;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
