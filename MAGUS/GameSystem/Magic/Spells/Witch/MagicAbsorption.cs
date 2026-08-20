using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Mágiaelnyelés (Boszorkány — Misztikus képesség, Első Törvénykönyv p.205). Self-buff that
/// neutralizes incoming spells at the cost of the witch's own Fp/Ép equal to the neutralized
/// spell's Mana cost. Not wired into the enemy-targeting combat pipeline.
/// </summary>
public sealed class MagicAbsorption : ISpell
{
    public string Name => "Magic absorption";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 30;

    public int GetDamage() => 0;
}
