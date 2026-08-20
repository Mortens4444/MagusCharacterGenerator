using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Halálsikoly (Sámán, Második Törvénykönyv p.115, Ráolvasások — Tömegre ható átkok). A terrifying
/// scream that turns the shaman's body into a gate between the Túlvilág and Földvilág, unleashing
/// formless demons on everyone within range — including the shaman's own allies. Anyone within 5 m
/// who fails their Magic Resistance against the spell's Erősség dies instantly; those 5-15 m away
/// instead risk permanent madness (failing both Astral and Mental resistance) or crippling pain
/// (failing one or neither, worth k10 FP per caster level and a 2-round paralysis). Represented
/// here as the outright-death effect directly, matching how Witch's KissOfDeath handles a similar
/// binary kill-or-not spell, since only one ResistanceType and one OnHit outcome can be modeled;
/// the graduated 5-15 m madness/pain tier and the friendly-fire nature of the blast are not
/// modeled. Book Erősség is 30 + caster level, book duration 1 day per level; level-1 baselines
/// used (not level-scaled). Book calls for both Asztrális and Mentális resistance; only Astral is
/// representable here.
/// </summary>
public sealed class DeathScream : ISpell
{
    public string Name => "Death scream";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => 30;

    public int ManaCost => 60;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.ActualHealthPoints = 0;
    }
}
