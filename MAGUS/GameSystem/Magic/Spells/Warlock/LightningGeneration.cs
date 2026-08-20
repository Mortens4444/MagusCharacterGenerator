using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Villámkeltés (Boszorkánymester — Villámmágia, Első Törvénykönyv p.241). Lets raw magical
/// energy flow freely through the caster's body. Duration is kör/szint in the book; level-1
/// baseline shown, not level-scaled. Halves the Mana cost of the caster's other lightning-damage
/// spells for the duration (at the cost of taking damage back from the energy); that cost
/// interaction isn't modeled here, this is a flavor-only catalog entry.
/// </summary>
public sealed class LightningGeneration : ISpell
{
    public string Name => "Lightning generation";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
