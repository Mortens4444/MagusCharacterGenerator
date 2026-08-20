using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Iránymutató (Sámán — Természeti mágia, Második Törvénykönyv p.127). An inner voice keeps the
/// shaman (or a touched ally) oriented to the compass points, or - in its other mode - locked onto
/// their current location so they can find their way back to it later. No concentration required.
/// This codebase has no navigation/way-point subsystem; this class exists only as a spellbook/
/// catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class DirectionSense : ISpell
{
    public string Name => "Direction sense";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 12;

    public int GetDamage() => 0;
}
