using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Lávafolyam (Boszorkánymester — Természeti Mágia, Első Törvénykönyv p.254). Opens a geyser of
/// molten lava at a point the caster chooses within range; any living thing it engulfs dies
/// instantly. Represents the rulebook's outright death directly, rather than approximating it as
/// a large damage roll. Named VolcanicEruption (not LavaFlow) to avoid colliding with the
/// unrelated Fire-school spell of that name.
/// </summary>
public sealed class VolcanicEruption : ISpell
{
    public string Name => "Volcanic eruption";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 95;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 100;

    public int DurationInRounds => 270;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.ActualHealthPoints = 0;
    }
}
