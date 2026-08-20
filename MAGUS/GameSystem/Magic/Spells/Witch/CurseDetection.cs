using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Átokfejtés (Boszorkány — Átkok, Első Törvénykönyv p.214). Reveals the identity and rough
/// power of the witch who cast a detected curse on a target; only works on Witch curses, not
/// Warlock ones.
/// </summary>
public sealed class CurseDetection : ISpell
{
    public string Name => "Curse detection";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 10;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 100;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
