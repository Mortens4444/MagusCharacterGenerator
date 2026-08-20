using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Hazugság (Boszorkány — Átkok, Első Törvénykönyv p.214). A Jellemtorzító Átok (character-flaw
/// curse) that turns the target into a compulsive liar, answering 25% of questions with
/// falsehoods, on a failed Astral resistance roll.
/// </summary>
public sealed class InflictLying : ISpell
{
    public string Name => "Inflict lying";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 8;

    public int ManaCost => 18;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
