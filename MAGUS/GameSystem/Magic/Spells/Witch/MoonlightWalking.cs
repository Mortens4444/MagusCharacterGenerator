using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Holdfényjárás (Boszorkány — Misztikus képesség, Első Törvénykönyv p.203). Lets the witch walk
/// on moonbeams, bridging lakes and rivers; under a full moon she can even walk on air, though she
/// must face the moon with her eyes shut the whole time. Duration is per caster level in minutes;
/// level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class MoonlightWalking : ISpell
{
    public string Name => "Moonlight walking";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
