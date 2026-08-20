using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Szertartás (Sámán, Második Törvénykönyv p.108). The umbrella ritual type behind the shaman's
/// ceremonial magic (as opposed to Szellemtánc-based trance magic): the shaman channels the
/// purifying, radiating power of the spirits rather than a personal trance. Its four base forms
/// (Megtisztítás/purification detection, and the Áldozat, Felruházás and Névadás rites elsewhere
/// in this chapter) are usually cast as components of other named rituals rather than standalone.
/// Book stats are themselves near-unusable for simulation (Mana-pont: Speciális, Erősség:
/// gyakorlatilag végtelen/practically infinite, Varázslás ideje and Hatótáv: Speciális, Időtartam:
/// Végleges); the Mana cost shown here is borrowed from the concrete Megtisztítás sub-form (3 Mp)
/// as the most representative documented number, and casting time from its "1 kör + változó"
/// baseline. This codebase has no ceremony/ritual-purification subsystem (curse/disease detection,
/// sacrifice bookkeeping, spirit goodwill tracking); this class exists only as a spellbook/catalog
/// entry with no simulated mechanical effect.
/// </summary>
public sealed class SpiritCeremony : ISpell
{
    public string Name => "Spirit ceremony";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
