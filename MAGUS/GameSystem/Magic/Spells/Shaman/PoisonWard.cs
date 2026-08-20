using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Méregpajzs (Sámán, Második Törvénykönyv p.110, Ráolvasások). Wards one touched person against
/// poison for the duration. Book duration is "1 nap négy Szintenként" (1 day per 4 caster levels);
/// the level-1 baseline of a flat 1 day is used here, not level-scaled. This codebase has no
/// poison-immunity/status subsystem to suppress future poison effects; this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class PoisonWard : ISpell
{
    public string Name => "Poison ward";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 15;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
