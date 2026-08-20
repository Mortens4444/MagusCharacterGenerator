using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Ösztön (Sámán — Állatszellem idézés, Második Törvénykönyv p.132-133). Grants the recipient a
/// chosen animal's sixth sense within its own habitat - unerring navigation, finding food and
/// water, spotting hidden dangers - at the cost of their human knowledge: no spellcasting, no Psi,
/// while it lasts. This codebase has no animal-instinct/survival subsystem; this class exists only
/// as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class PredatorInstinct : ISpell
{
    public string Name => "Predator instinct";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 28;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 610;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
