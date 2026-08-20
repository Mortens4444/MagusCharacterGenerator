using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Szolga hívása (Tűzvarázsló, Első Törvénykönyv p.280). Egy legalább 5E erősségű tűzön át
/// kaput nyit a Tűz Elemi Síkjára, ahonnan egy elementál Szolga lép át, és engedelmeskedik a
/// tűzvarázsló minden parancsának. The rulebook summons an autonomous elemental creature with
/// its own combat stats (Harcmódosító, multiple attacks per round, its own HP/FP) that fights
/// independently for the spell's duration — none of that is modeled here; GetDamage represents
/// only a single hit's damage from the creature's book stat block, which is not specified for
/// the Szolga (left to the Bestiárium), so it deals no damage here. Fire-school damage bypasses
/// magic resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class SummonServant : ISpell
{
    public string Name => "Summon servant";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 24;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 30;

    public int DurationInRounds => 4;

    public int GetDamage() => 0;
}
