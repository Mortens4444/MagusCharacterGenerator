using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Bagolyszem (Boszorkánymester — Alapvarázslatok, Első Törvénykönyv p.240). Grants the caster
/// (or a touched creature) daylight-sharp vision in near-total darkness for 4 hours; a sudden
/// bright light while active causes permanent blindness.
/// </summary>
public sealed class OwlEye : ISpell
{
    public string Name => "Owl eye";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 1440;

    public int GetDamage() => 0;
}
