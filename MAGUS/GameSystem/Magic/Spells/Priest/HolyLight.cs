using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Priest;

/// <summary>
/// Szent fény (Kis Arkánum Litániái — general, any priest). Creates blessed light on consecrated
/// objects/places, wards darkness magic, and warns of hostile/dangerous presences nearby. Not an
/// attack, so it deals no damage and isn't wired into the enemy-targeting combat pipeline.
/// </summary>
public sealed class HolyLight : ISpell
{
    public string Name => "Holy light";

    public MagicSchool School => MagicSchool.Priest;

    public Sphere[] Spheres => [Sphere.Life, Sphere.Death, Sphere.Soul, Sphere.Nature];

    public int? Power => 15;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 2;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
