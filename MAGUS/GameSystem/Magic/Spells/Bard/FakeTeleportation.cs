using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Hamis teleportáció (Bárd — Fénymágia, Első Törvénykönyv p.148). Convinces the target(s) they
/// were teleported to a bleak wasteland, without actually moving them. Duration is 6 kör/szint in
/// the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class FakeTeleportation : ISpell
{
    public string Name => "Fake teleportation";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 25;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 36;

    public int GetDamage() => 0;
}
