using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Árnyak (Boszorkány — Misztikus képesség, Első Törvénykönyv p.203). Lets the witch stretch or
/// shrink the shadows in an area by up to 50%, making hiding easier or harder there. Duration is
/// per caster level in minutes; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class Shadows : ISpell
{
    public string Name => "Shadows";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
