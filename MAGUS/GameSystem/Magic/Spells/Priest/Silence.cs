using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Priest;

/// <summary>
/// Csend (Szférikus — Természet). Creates a zone of silence (moves with the target if cast on a
/// creature). Not a damage effect, and this engine has no sound/spellcasting-suppression system to
/// model it mechanically, so it deals no damage and isn't wired into the enemy-targeting combat
/// pipeline. Duration is "1 kör/szint" (per caster level, not modeled per-level here —
/// approximated as a flat few rounds).
/// </summary>
public sealed class Silence : ISpell
{
    public string Name => "Silence";

    public MagicSchool School => MagicSchool.Priest;

    public Sphere[] Spheres => [Sphere.Nature];

    public int? Power => 5;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 3;

    public int GetDamage() => 0;
}
