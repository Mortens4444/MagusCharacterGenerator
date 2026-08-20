using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Láthatatlanság (Bárd — Fénymágia, Első Törvénykönyv p.140). Makes the bard invisible to normal,
/// infra- and ultravision — but light passes through the caster's own eyes too, so they're blind
/// for the duration. Self-only; a self-buff, not wired into the enemy-targeting pipeline.
/// </summary>
public sealed class Invisibility : ISpell
{
    public string Name => "Invisibility";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
