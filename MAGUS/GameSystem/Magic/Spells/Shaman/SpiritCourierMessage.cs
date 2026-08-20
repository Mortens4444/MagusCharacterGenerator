using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Üzenet (Sámán — Szabad mágia, Második Törvénykönyv p.122). Opens a one-way conversation with
/// any chosen person, who can reply without knowing magic or Psi themselves; a spirit courier
/// (100 km/hour) physically relays the words, so long distances take real time. Casting time is
/// "Speciális" in the book (dependent on courier travel time); approximated here as a single
/// round to send. This codebase has no messenger/courier subsystem; this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class SpiritCourierMessage : ISpell
{
    public string Name => "Spirit courier message";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 17;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
