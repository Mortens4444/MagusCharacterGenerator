using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Kovácsolás (Sámán, Második Törvénykönyv p.108-109, Ráolvasások). One of shamanic magic's
/// pinnacles: a composite ritual (animal sacrifice, then Felruházás-empowered ink-and-blood
/// symbols drawn glowing over every wound while chanting) that heals broken bones, torn tendons,
/// severed limbs (if the limb was preserved and handed to the shaman) and ordinary wounds alike.
/// Book cost is 1 kör casting and 3 Mp + 1 FP per every 3rd point of ÉP healed, i.e. per-point
/// scaling with no fixed total; the level-1/single-point baseline (heal 1 ÉP for 3 Mp + 1 FP, 1
/// round) is used here, matching how other level-scaled book formulas are approximated elsewhere in
/// this chapter. The heavy post-cast Weakness penalty (halved Erő, and reduced KÉ/TÉ/VÉ) and the
/// separate Áldozat/Megtisztítás/Felruházás sub-rituals it bundles are not modeled.
/// </summary>
public sealed class SpiritForging : ISpell
{
    public string Name => "Spirit forging";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 3;

    public int PainTolerancePointCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.ActualHealthPoints += 1;
    }
}
