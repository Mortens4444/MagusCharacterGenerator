using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Madárszem (Sámán — Szabad mágia, Második Törvénykönyv p.123). Lets the shaman see through the
/// eyes of a bird flying overhead, choosing among any birds visible and directing its flight. Cast
/// during Szellemtánc; cannot be empowered, and only works on winged, bird-intelligence creatures.
/// This codebase has no remote-scrying/animal-possession subsystem; this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class RemoteBirdSight : ISpell
{
    public string Name => "Remote bird sight";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 10;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 40;

    public int DurationInRounds => 61;

    public int GetDamage() => 0;
}
