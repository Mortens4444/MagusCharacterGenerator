using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Priest;

/// <summary>
/// A hatalom szava (Kis Arkánum Litániái — general, any priest). Reveals the caster's true
/// spiritual power to everyone within a 30-foot radius; not an attack, so it deals no damage and
/// isn't wired into the enemy-targeting combat pipeline.
/// </summary>
public sealed class WordOfPower : ISpell
{
    public string Name => "Word of power";

    public MagicSchool School => MagicSchool.Priest;

    public Sphere[] Spheres => [Sphere.Life, Sphere.Death, Sphere.Soul, Sphere.Nature];

    public int? Power => 35;

    public int ManaCost => 15;

    public int PowerBonusPerManaPoint => 2;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
