using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Dögemésztés (Sámán — Állatszellem idézés, Második Törvénykönyv p.133). Hyena-blood sigil drawn
/// on the belly lets the recipient safely eat rotten, spoiled or outright putrid food and drink
/// filthy water without harm for the duration. This codebase has no food-poisoning/survival
/// subsystem; this class exists only as a spellbook/catalog entry with no simulated mechanical
/// effect.
/// </summary>
public sealed class CarrionFeast : ISpell
{
    public string Name => "Carrion feast";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 17;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 190;

    public int DurationInRounds => 4320;

    public int GetDamage() => 0;
}
