using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Ködalak (Bárd — Fénymágia, Első Törvénykönyv p.140). Blurs the bard's outline; attacks against
/// them suffer -15 melee / -30 ranged. Self-only defensive illusion; not modeled since Attacker
/// has no way to reduce incoming-attack rolls against itself, only apply penalties to others.
/// Duration is 3 kör/szint in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class BlurredForm : ISpell
{
    public string Name => "Blurred form";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 3;

    public int GetDamage() => 0;
}
