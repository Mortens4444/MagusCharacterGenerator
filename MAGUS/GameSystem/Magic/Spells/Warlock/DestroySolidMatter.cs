using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Szilárd anyag pusztítás (Boszorkánymester — Anyagmágia, Első Törvénykönyv p.244). Annihilates
/// a small quantity of non-magical solid matter (an object, not a part of one); cannot target
/// the bodies, gear, or equipment of living creatures.
/// </summary>
public sealed class DestroySolidMatter : ISpell
{
    public string Name => "Destroy solid matter";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
