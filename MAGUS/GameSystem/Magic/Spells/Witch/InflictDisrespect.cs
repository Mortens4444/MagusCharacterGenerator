using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Tiszteletlenség (Boszorkány — Átkok, Első Törvénykönyv p.215). A Jellemtorzító Átok
/// (character-flaw curse) that turns the target insolent toward everyone they'd normally
/// respect, on a failed Astral resistance roll.
/// </summary>
public sealed class InflictDisrespect : ISpell
{
    public string Name => "Inflict disrespect";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 8;

    public int ManaCost => 10;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
