using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Halál csókja (Boszorkány — Csókmágia, Első Törvénykönyv p.224). The kiss of death delivers
/// heavenly bliss to whoever receives it — the price being that a failed Asztrális resistance
/// roll stops the victim's heart, an eternal smile frozen on their face. Represents the rulebook's
/// outright death directly, rather than approximating it as a large damage roll. Book duration is
/// "maradandó" (permanent); approximated as a long but finite value.
/// </summary>
public sealed class KissOfDeath : ISpell
{
    public string Name => "Kiss of death";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 15;

    public int ManaCost => 52;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.ActualHealthPoints = 0;
    }
}
