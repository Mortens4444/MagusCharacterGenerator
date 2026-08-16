using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Priest;

/// <summary>
/// Áldás (Kis Arkánum Litániái — general, any priest). A touch buff granting courage/resolve
/// (+5 to mental magic resistance rolls); cast on an ally, not an attack, so it deals no damage
/// and isn't wired into the enemy-targeting combat pipeline.
/// </summary>
public sealed class Blessing : ISpell
{
    public string Name => "Blessing";

    public MagicSchool School => MagicSchool.Priest;

    public Sphere[] Spheres => [Sphere.Life, Sphere.Death, Sphere.Soul, Sphere.Nature];

    public int? Power => 5;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 2;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 2;

    public int GetDamage() => 0;
}
