using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Lebegés (Sámán, Második Törvénykönyv p.110). Lets the shaman rise and float, minimum a hand's
/// span and maximum 5 meters up, moving horizontally or vertically at up to a walking pace over
/// land or water. Needs no continuous concentration — the shaman can fight or cast other spells
/// while airborne — but cannot perform any spell that itself requires Szellemtánc while levitating.
/// Self-only; requires Kántálás (chanting) to cast, named `SpiritLevitation` to avoid colliding
/// with the unrelated Witch-school `Levitate` spell class. Duration is 1 perc/Szint in the book;
/// level-1 baseline (1 minute = 6 rounds) shown, not level-scaled. Beyond the listed cost, every
/// further started minute (up to a maximum of the shaman's Experience Level in minutes) costs an
/// extra 1 FP; that per-minute scaling is left unmodeled, but the base Mana-pont figure (9 Mp + 3
/// FP in the book) is fully modeled via ManaCost/PainTolerancePointCost.
/// </summary>
public sealed class SpiritLevitation : ISpell
{
    public string Name => "Spirit levitation";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 9;

    public int PainTolerancePointCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
