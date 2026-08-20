using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Fénysugár (Bárd — Fénymágia, Első Törvénykönyv p.143). Conjures a long, brilliant beam of light
/// from the bard's palm, rivaling a lighthouse — visible from miles away on a clear day. Duration
/// is 3 kör/szint in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class LightBeam : ISpell
{
    public string Name => "Light beam";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 9;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 3;

    public int GetDamage() => 0;
}
