using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Priest;

/// <summary>
/// Élelemteremtés (Szférikus — Élet, Természet). Conjures food/drink enough for 3 people or one
/// horse-sized creature. Pure utility, not an attack, so it deals no damage and isn't wired into
/// the enemy-targeting combat pipeline.
/// </summary>
public sealed class CreateFood : ISpell
{
    public string Name => "Create food";

    public MagicSchool School => MagicSchool.Priest;

    public Sphere[] Spheres => [Sphere.Life, Sphere.Nature];

    public int? Power => 5;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 999;

    public int GetDamage() => 0;
}
