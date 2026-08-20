using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Szellemújjak (Sámán — Szabad mágia, Második Törvénykönyv p.123). A simplified cousin of
/// Lebegés: with spirit help the shaman nudges small, light objects within sight - pulling a
/// dropped weapon closer, turning a key, plucking a herb - but only slow movement, unusable to
/// throw or wield a weapon. Cast during kántálás only. This codebase has no fine-grained
/// object-telekinesis subsystem; this class exists only as a spellbook/catalog entry with no
/// simulated mechanical effect.
/// </summary>
public sealed class MinorTelekinesis : ISpell
{
    public string Name => "Minor telekinesis";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 2;

    public int GetDamage() => 0;
}
