using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Lángkitörés (Tűzvarázsló, Első Törvénykönyv p.281). Halálakor minden tűzvarázsló képes
/// pusztító Lángkitörésben felszabadítani testi és szellemi energiáit; sugarasan szétágazó
/// tűznyelvek csapnak elő az áldozat testéből, ha az elveszíti mind az Asztrális, mind a
/// Mentális mágiaellenállását. Represents the rulebook's outright death on a failed resistance
/// roll directly, rather than approximating it as a large damage roll. Unlike other Fire-school
/// spells, this one explicitly requires both an Asztrális and Mentális resistance roll (p.281);
/// ISpell only models one ResistanceType, so Astral is used and Power is non-null here.
/// </summary>
public sealed class FlameEruption : ISpell
{
    public string Name => "Flame eruption";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => 10;

    public int ManaCost => 17;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.ActualHealthPoints = 0;
    }
}
