using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Tárgy átváltoztatás (Bárd — Fénymágia, Első Törvénykönyv p.142). Makes an existing object look
/// like a different material, color or finish (a wooden table appearing to be stone or gold);
/// the object's true nature is unchanged, and touch reveals the illusion instantly. Duration is
/// 1 nap/szint (1 day per level) in the book; level-1 baseline (24 hours = 8640 rounds) shown,
/// not level-scaled.
/// </summary>
public sealed class ObjectTransformation : ISpell
{
    public string Name => "Object transformation";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
