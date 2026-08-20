using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Iszákosság (Boszorkány — Átkok, Első Törvénykönyv p.215-216). A Jellemtorzító Átok
/// (character-flaw curse) that turns the target into a compulsive drinker, on a failed Astral
/// resistance roll.
/// </summary>
public sealed class InflictAlcoholism : ISpell
{
    public string Name => "Inflict alcoholism";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 7;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
