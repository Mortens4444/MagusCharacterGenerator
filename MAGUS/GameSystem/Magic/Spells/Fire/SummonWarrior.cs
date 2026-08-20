using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Harcos hívása (Tűzvarázsló, Első Törvénykönyv p.280). A Szolga hívásához hasonlóan kaput
/// nyit a Tűz Elemi Síkjára, de egy legalább 8E erősségű tűz (tűzvész) szükséges hozzá, és egy
/// erősebb elementál - egy Harcos - lép át. The rulebook summons an autonomous elemental
/// creature with its own combat stats (Harcmódosító, multiple attacks per round, its own
/// HP/FP) that fights independently for the spell's duration — none of that is modeled here;
/// GetDamage represents only a single hit's damage from the creature's book stat block, which
/// is not specified for the Harcos (left to the Bestiárium), so it deals no damage here.
/// Fire-school damage bypasses magic resistance entirely per the rulebook (p.267), hence Power
/// is null.
/// </summary>
public sealed class SummonWarrior : ISpell
{
    public string Name => "Summon warrior";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 40;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 30;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
