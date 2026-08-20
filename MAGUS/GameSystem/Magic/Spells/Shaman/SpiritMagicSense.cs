using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Mágiaérzékelés (Sámán — Szabad mágia, Második Törvénykönyv p.120). Cast during Szellemtánc;
/// lets the shaman sense the presence, location and source of any magic (object, person, place)
/// within a 20 meter radius, except forms hidden by stronger Leplezés (Concealment). No resistance
/// roll in the book. This codebase has no magic-detection/concealment subsystem; this class exists
/// only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class SpiritMagicSense : ISpell
{
    public string Name => "Spirit magic sense";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
