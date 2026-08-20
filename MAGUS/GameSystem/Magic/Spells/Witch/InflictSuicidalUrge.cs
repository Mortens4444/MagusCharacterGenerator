using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Öngyilkos hajlam (Boszorkány — Átkok, Első Törvénykönyv p.215). A Jellemtorzító Átok
/// (character-flaw curse) that wrecks the target's self-worth until the smallest setback drives
/// them to suicide attempts, on a failed Astral resistance roll.
/// </summary>
public sealed class InflictSuicidalUrge : ISpell
{
    public string Name => "Inflict suicidal urge";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 8;

    public int ManaCost => 50;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
