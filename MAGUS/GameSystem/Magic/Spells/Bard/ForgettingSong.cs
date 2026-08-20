using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Feledés dala (Bárd — Dalmágia, Első Törvénykönyv p.135). Erases a single day's memories from
/// the target if their resistance fails; the target knows the day existed but recalls nothing of
/// it. Pure utility/narrative effect; no combat mechanic modeled.
/// </summary>
public sealed class ForgettingSong : ISpell
{
    public string Name => "Forgetting song";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => 12;

    public int ManaCost => 20;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 180;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
