using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Priest;

/// <summary>
/// Aszkézis (Kis Arkánum Rituálói — general, any priest). A self-only purification fast/meditation
/// ritual granting absolution of sin. Takes roughly 1 hour to perform and lasts about a day; no
/// resistance roll applies (hence Power is null). Not an attack, so it deals no damage and isn't
/// wired into the enemy-targeting combat pipeline.
/// </summary>
public sealed class Asceticism : ISpell
{
    public string Name => "Asceticism";

    public MagicSchool School => MagicSchool.Priest;

    public Sphere[] Spheres => [Sphere.Life, Sphere.Death, Sphere.Soul, Sphere.Nature];

    public int? Power => null;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 999;

    public int GetDamage() => 0;
}
