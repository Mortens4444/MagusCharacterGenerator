using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Nyilzápor (Bárd — Fénymágia, Első Törvénykönyv p.148-149). Multiplies the image of a fired or
/// thrown projectile into a swarm of illusory duplicates. Book effect (illusory duplicate
/// projectiles making an attacker's true shot nearly impossible to dodge, zeroing non-illusion-
/// based VÉ) is too specific to this codebase's ranged-defense model to represent as a flat
/// modifier; flavor-only here, no OnHit. Duration is kör/szint in the book; level-1 baseline
/// shown, not level-scaled.
/// </summary>
public sealed class ArrowStorm : ISpell
{
    public string Name => "Arrow storm illusion";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
