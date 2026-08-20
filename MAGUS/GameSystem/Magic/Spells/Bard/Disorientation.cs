using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Irányvesztés (Bárd — Fénymágia, Első Törvénykönyv p.147). Makes familiar landmarks reappear
/// along a target's path, as if they were walking in circles, disorienting them (and anyone
/// travelling with them). Duration is 15 perc/szint in the book; level-1 baseline shown, not
/// level-scaled.
/// </summary>
public sealed class Disorientation : ISpell
{
    public string Name => "Disorientation";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 90;

    public int GetDamage() => 0;
}
