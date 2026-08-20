using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Orgyilkosság (Boszorkánymester — Mentálmágia, Első Törvénykönyv p.256). Plants a compulsion to
/// murder a specific named target, lasting until that target's death or the spell is dispelled;
/// approximated as a long but finite duration. Pure narrative compulsion, no combat mechanic
/// given.
/// </summary>
public sealed class ImplantAssassination : ISpell
{
    public string Name => "Implant assassination compulsion";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => 10;

    public int ManaCost => 23;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
