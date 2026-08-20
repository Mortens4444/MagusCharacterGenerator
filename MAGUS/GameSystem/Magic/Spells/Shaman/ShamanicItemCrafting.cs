using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Varázstárgykészítés (Sámán, Második Törvénykönyv p.110). Lets the shaman craft any of the
/// experience-made magic items listed in the Sámánmágia Varázstárgyak (Magic Items) chapter. The
/// book gives no fixed stat block at all — Mana-pont is "amennyi az adott varázstárgynál szerepel"
/// (whatever the specific item's own entry lists), and Erősség/Varázslás ideje/Hatótáv/Időtartam
/// are all "lásd a leírásban" (see that item's description) — because each crafted item defines
/// its own cost and effect. ManaCost (5), CastingTimeInSegments (10) and DurationInRounds (1) here
/// are low placeholders with no basis in a specific worked example, since the individual magic
/// item entries this spell depends on are outside this chapter slice. This codebase has no
/// magic-item-crafting subsystem; this class exists only as a spellbook/catalog entry with no
/// simulated mechanical effect.
/// </summary>
public sealed class ShamanicItemCrafting : ISpell
{
    public string Name => "Shamanic item crafting";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
