using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Priest;

/// <summary>
/// Mágia szétoszlatása (Kis Arkánum Rituálói — general, any priest). Dispels a targeted spell if
/// the caster's committed mana exceeds the target spell's mana cost; the caster is then stunned
/// for a number of rounds equal to the dispelled spell's power. Targets a spell, not a creature,
/// so it deals no damage and isn't wired into the enemy-targeting combat pipeline.
/// </summary>
public sealed class DispelMagic : ISpell
{
    public string Name => "Dispel magic";

    public MagicSchool School => MagicSchool.Priest;

    public Sphere[] Spheres => [Sphere.Life, Sphere.Death, Sphere.Soul, Sphere.Nature];

    public int? Power => 5;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 2;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
