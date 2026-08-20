using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Sárkánybőr (Tűzvarázsló, Első Törvénykönyv p.272). A protective touch spell that neutralizes
/// part of any natural or elemental fire/heat damage, scaling with the caster's Experience
/// Level. Duration in the book is TSZ+10 perc (caster level dependent); DurationInRounds here is
/// the level-1 baseline ((1+10)×6 rounds), not level-scaled. Grants defense rather than dealing
/// damage, so Power is null.
/// </summary>
public sealed class DragonSkin : ISpell
{
    public string Name => "Dragon skin";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 27;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 30;

    public int DurationInRounds => 66;

    public int GetDamage() => 0;
}
