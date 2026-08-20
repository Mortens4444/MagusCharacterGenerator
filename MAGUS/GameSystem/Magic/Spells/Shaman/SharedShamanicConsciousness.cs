using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Szólítás - Közös sámántudat (Sámán, Második Törvénykönyv p.118-119, Idézőmágia). Not a
/// creature summons despite sitting in the Idézőmágia chapter alongside them: a Szellemtánc rite
/// that links the shaman's mind to that of another shaman (or several), letting a less powerful,
/// lower-level shaman support and lend awareness to a more capable one. While active the shaman
/// can concentrate on nothing else, sometimes for half a day or more. This codebase has no
/// multi-caster mind-link/shared-consciousness subsystem; this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class SharedShamanicConsciousness : ISpell
{
    public string Name => "Shared shamanic consciousness";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 80;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
