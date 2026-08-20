using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Kígyóvarázs III. (Boszorkány — Asztrálmágia, Első Törvénykönyv p.210). Grants an already-live
/// snake rope-like properties (stretch, limpness, knottability) without transforming it into an
/// actual rope. Power is null (book ME "-"). Duration is kör/szint in the book; level-1 baseline
/// shown, not level-scaled.
/// </summary>
public sealed class RopeToSnakeIII : ISpell
{
    public string Name => "Rope to snake III";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
