using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Földmozgás (Boszorkánymester — Természeti Mágia, Első Törvénykönyv p.253-254). A minor
/// earthquake over a 1-mile-radius area; topples unstable structures and rotten trees, and can
/// trigger avalanches in mountains. No direct HP damage is given in the book.
/// </summary>
public sealed class Earthquake : ISpell
{
    public string Name => "Earthquake";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 55;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 100;

    public int DurationInRounds => 270;

    public int GetDamage() => 0;
}
