using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Betegség átadása (Boszorkány — Ölelésmágia, Első Törvénykönyv p.226). Implants a
/// Rontás-style magical disease (per the Warlock disease chapter) into a touched victim through
/// intercourse; the specific disease's own effects aren't modeled, matching how the Warlock
/// disease classes are also catalog-only entries. Not to be confused with the unrelated Warlock
/// TransferDisease class (a different Hungarian spell of the same name under Betegségmágia) —
/// deliberately renamed to InflictMagicalDisease to avoid a class-name collision. Book Mana cost
/// is 6 + 5 per intended disease level; 11 (6+5, i.e. a level-1 disease) shown as the base cost.
/// Book resistance is an Egészségpróba, not modeled, hence Power is null.
/// </summary>
public sealed class InflictMagicalDisease : ISpell
{
    public string Name => "Inflict magical disease";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 11;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
