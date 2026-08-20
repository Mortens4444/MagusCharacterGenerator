using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Csapás (Sámán, Második Törvénykönyv p.114-115, Ráolvasások — Tömegre ható átkok). Feared most
/// by priests: a possessing spirit cuts the victim off from their own Mana points (and, as later
/// discovered, Psi points too) for caster level × 2 hours, undetectable and unnoticed until the
/// victim tries to draw on them. Interrupted for free if the victim hears the shaman's shouted
/// command word while casting their own magic. Removable early only by a shaman's Átokűzés or an
/// equally powerful priest exorcism. Book Erősség is 40 + caster level, level-1 baseline used (not
/// level-scaled). This codebase has no mechanism to block a target's access to their own Mana/Psi
/// pool mid-combat; this class exists only as a spellbook/catalog entry with no simulated
/// mechanical effect.
/// </summary>
public sealed class SpiritSilence : ISpell
{
    public string Name => "Spirit silence";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => 40;

    public int ManaCost => 40;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 720;

    public int GetDamage() => 0;
}
