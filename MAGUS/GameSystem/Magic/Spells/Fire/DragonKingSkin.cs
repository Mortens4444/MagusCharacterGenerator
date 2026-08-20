using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Sárkánykirály bőre (Tűzvarázsló, Első Törvénykönyv p.272). Like Dragon skin, but grants total
/// invulnerability to fire and heat of any Strength while active. Duration in the book is
/// TSZ+10 perc (caster level dependent); DurationInRounds here is the level-1 baseline
/// ((1+10)×6 rounds), not level-scaled. Grants defense rather than dealing damage, so Power is
/// null.
/// </summary>
public sealed class DragonKingSkin : ISpell
{
    public string Name => "Dragon king's skin";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 60;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 66;

    public int GetDamage() => 0;
}
