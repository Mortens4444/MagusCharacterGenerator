using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Személy megkeresése (Boszorkány — Szimpatikus Mágia, Első Törvénykönyv p.227-228). Requires a
/// sympathetic object (hair, nail clipping) from the target. Duration is 1 óra/szint; level-1
/// baseline shown, not level-scaled.
/// </summary>
public sealed class PersonSeeking : ISpell
{
    public string Name => "Person seeking";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 15;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 30;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
