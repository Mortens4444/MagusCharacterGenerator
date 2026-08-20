using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Gyilkos hajlam (Boszorkány — Átkok, Első Törvénykönyv p.215). A Jellemtorzító Átok
/// (character-flaw curse) that makes the target value human life at nothing, drawing a weapon
/// over the smallest slight, on a failed Astral resistance roll.
/// </summary>
public sealed class InflictMurderousUrge : ISpell
{
    public string Name => "Inflict murderous urge";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 8;

    public int ManaCost => 35;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
