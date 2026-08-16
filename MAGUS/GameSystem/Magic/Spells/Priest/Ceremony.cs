using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Priest;

/// <summary>
/// Szertartás (Kis Arkánum Rituálói — general, any priest). The base rite behind temple
/// consecration, naming ceremonies, sanctifying water/objects, blessing food/land, and weddings
/// (7 sub-rituals). A permanent ritual effect, not an attack, so it deals no damage and isn't
/// wired into the enemy-targeting combat pipeline. Casting time and duration are "Speciális" per
/// the rulebook (varies by sub-ritual); approximated here as 1 round to cast and effectively
/// permanent.
/// </summary>
public sealed class Ceremony : ISpell
{
    public string Name => "Ceremony";

    public MagicSchool School => MagicSchool.Priest;

    public Sphere[] Spheres => [Sphere.Life, Sphere.Death, Sphere.Soul, Sphere.Nature];

    public int? Power => 500;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 2;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 999;

    public int GetDamage() => 0;
}
