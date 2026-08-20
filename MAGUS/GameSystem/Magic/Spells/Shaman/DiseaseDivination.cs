using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Betegségfejtés (Sámán, Második Törvénykönyv p.109-110, Ráolvasások). Shares Átokfejtés's stat
/// block and Szellemtánc ritual (the shaman circles the patient, questioning the spirits while
/// chanting) but is aimed at natural disease: reveals a disease's true nature and current
/// severity, or (for magical rontás) also who cast it, their caste and rough power. Recommended
/// before Betegségelhárítás. Duration is listed as "Egy vizsgálat" (one examination/session);
/// approximated here as instantaneous. This codebase has no disease/curse diagnosis subsystem;
/// this class exists only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class DiseaseDivination : ISpell
{
    public string Name => "Disease divination";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
