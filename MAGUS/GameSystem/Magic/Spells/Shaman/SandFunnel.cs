using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Homoktölcsér (Sámán — Természeti mágia, Második Törvénykönyv p.126). A minor sand/dust vortex,
/// scaling in radius with Tapasztalati Szint. Book duration reads "1 nap / 20 kör" (whichever ends
/// it first, likely lasting until the wind dies down); the shorter, round-based reading is used
/// here. This codebase has no localized-vortex/terrain subsystem; this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class SandFunnel : ISpell
{
    public string Name => "Sand funnel";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 15;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 20;

    public int GetDamage() => 0;
}
