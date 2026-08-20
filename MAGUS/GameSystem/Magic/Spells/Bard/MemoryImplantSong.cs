using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Emlékek dala (Bárd — Dalmágia, Első Törvénykönyv p.135, the unnamed song directly following
/// Bénítás dala whose stat block reads Mana-pont 25 / Erősség 12 / Varázslás ideje 3 perc /
/// Időtartam végleges / Mágiaellenállás Mentális). Lets the bard implant up to a day's worth of
/// false memories into the target's mind, if their resistance fails. Pure utility/narrative
/// effect; no combat mechanic modeled.
/// </summary>
public sealed class MemoryImplantSong : ISpell
{
    public string Name => "Memory implant song";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => 12;

    public int ManaCost => 25;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 180;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
