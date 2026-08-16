using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Priest;

/// <summary>
/// Asztrálpillantás (Szférikus — Élet, Lélek). Lets the caster peek at a touched target's astral
/// body and any threats to it. Not an attack, so it deals no damage and isn't wired into the
/// enemy-targeting combat pipeline.
/// </summary>
public sealed class AstralGlimpse : ISpell
{
    public string Name => "Astral glimpse";

    public MagicSchool School => MagicSchool.Priest;

    public Sphere[] Spheres => [Sphere.Life, Sphere.Soul];

    public int? Power => 5;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 5;

    public int GetDamage() => 0;
}
