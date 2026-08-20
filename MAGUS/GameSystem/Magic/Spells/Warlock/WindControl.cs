using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Szélirányítás (Boszorkánymester — Természeti Mágia, Első Törvénykönyv p.254). Changes wind
/// speed and direction within a 1-mile-radius area; requires at least some minimal existing
/// air movement to work with, and continuous concentration to keep adjusting it.
/// </summary>
public sealed class WindControl : ISpell
{
    public string Name => "Wind control";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 20;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 100;

    public int DurationInRounds => 270;

    public int GetDamage() => 0;
}
