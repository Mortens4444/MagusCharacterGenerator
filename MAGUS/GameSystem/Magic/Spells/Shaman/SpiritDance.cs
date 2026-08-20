using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Szellemtánc (Ekstázis) (Sámán, Második Törvénykönyv p.108). The first spell every shaman
/// learns and the trance nearly all other shaman magic is cast through: a continuous dance done
/// to alternating drumbeat and chant that opens contact with the Szellemvilág (Spirit World).
/// Entering the trance takes at least 1 round (an Astral check at the end of each round until it
/// succeeds, after which no more checks are needed); while dancing the shaman perceives the
/// surroundings normally but cannot speak, fight, move quickly, or otherwise act without breaking
/// the trance (and the spell chained to it). Casting time is listed as "1 kör + varázslat" (1
/// round plus whatever the chained spell itself needs); only the 1-round baseline is modeled here,
/// not the chained spell's extra time. Duration is listed as Speciális (lasts as long as the
/// shaman wishes); approximated here as a long but finite value. The book's Mana cost is unusual:
/// no Mana points are spent at all in the normal case, only 1 Fájdalomtűrés (pain tolerance) point
/// every 6 rounds sustained; approximated here as a flat 1 FP paid once at cast time via
/// PainTolerancePointCost, since this engine has no per-round upkeep-tick mechanism. The trance also grants a Psi Kyr-style Aura Érzékelés
/// perception (base strength 10, +2 per further Mana point spent), which is likewise not modeled
/// since it has no combat effect here.
/// </summary>
public sealed class SpiritDance : ISpell
{
    public string Name => "Spirit dance";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 0;

    public int PainTolerancePointCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
