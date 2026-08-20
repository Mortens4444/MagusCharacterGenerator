using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Révület (Sámán, Második Törvénykönyv p.107-108). The only ritual way a shaman can recover
/// spent Mana points: a deep trance (cast through Szellemtánc) that reconnects the shaman to the
/// Szellemvilág, ending with the shaman's Mana points restored to their maximum. Duration scales
/// with how many Mana points are being recovered (5 segments per point); the book's worked example
/// of the "magical energy" method (1 Mp + 1 FP to enter, at a baseline of 1 point recovered) is
/// used here, giving a 1 round + 5 segment casting baseline — not level/amount-scaled. An
/// alternative "bodily energy" method costs 1D6+2 FP and no Mana at all; that variant, and the
/// 2D6+1 minutes of Kábultság (dazed, unable to cast) afterward either method causes, are not
/// modeled. Listed duration is Végleges (final/permanent once entered); approximated here as a
/// long but finite value. While in Révület the shaman cannot be talked or physically startled out
/// of it; only a wound dealing ÉP damage interrupts it.
/// </summary>
public sealed class Revelation : ISpell
{
    public string Name => "Revelation";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 1;

    public int PainTolerancePointCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 15;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
