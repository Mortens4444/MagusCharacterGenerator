using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Hangutánzás (Sámán — Állatszellem idézés, Második Törvénykönyv p.133). A simple sigil around
/// the mouth lets the recipient reproduce a chosen animal's call; imperfect, so only a listener
/// with a relevant Képzettség (Hangutánzás, Erdőjárás, ...) has any real chance of spotting the
/// deception. This codebase has no animal-call/deception-check subsystem; this class exists only
/// as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class CreatureCallMimicry : ISpell
{
    public string Name => "Creature call mimicry";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 70;

    public int DurationInRounds => 5;

    public int GetDamage() => 0;
}
