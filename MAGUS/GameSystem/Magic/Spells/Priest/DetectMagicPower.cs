using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Priest;

/// <summary>
/// Mágia kifürkészése (Kis Arkánum Litániái — general, any priest). Reveals the power level of a
/// targeted spell (pairs with Dispel Magic). Targets a spell, not a creature, so it deals no
/// damage and isn't wired into the enemy-targeting combat pipeline.
/// </summary>
public sealed class DetectMagicPower : ISpell
{
    public string Name => "Detect magic power";

    public MagicSchool School => MagicSchool.Priest;

    public Sphere[] Spheres => [Sphere.Life, Sphere.Death, Sphere.Soul, Sphere.Nature];

    public int? Power => 10;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 2;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
