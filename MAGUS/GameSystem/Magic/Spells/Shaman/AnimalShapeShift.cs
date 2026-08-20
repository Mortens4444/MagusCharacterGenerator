using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Átváltozás (Sámán — Szabad mágia, Második Törvénykönyv p.122). Transforms the shaman's body
/// (not gear) into a wolf, bear, tiger, lion, small forest mammal or bird of prey, granting that
/// animal's Bestiarium stats and combat values while keeping the shaman's own ÉP/FP. This codebase
/// has no shapeshifting/beast-form subsystem; this class exists only as a spellbook/catalog entry
/// with no simulated mechanical effect.
/// </summary>
public sealed class AnimalShapeShift : ISpell
{
    public string Name => "Animal shape shift";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 53;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 210;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
