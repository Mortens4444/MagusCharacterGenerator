using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Álmok asszonya (Boszorkány — Bájolás, Első Törvénykönyv p.222). Lets the witch temporarily
/// shift her own appearance toward a previously-probed target's ideal (via Fürkészés); self-buff,
/// not wired into the enemy-targeting pipeline. Duration is 1 óra/szint in the book; level-1
/// baseline shown, not level-scaled.
/// </summary>
public sealed class DreamWoman : ISpell
{
    public string Name => "Dream woman";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 16;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
