using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Medvemancs (Sámán — Állatszellem idézés, Második Törvénykönyv p.129-130). A bear-blood sigil
/// drawn on the recipient's palm and forearm sharpens melee strikes, adding +2 SP (an Erő bonus,
/// so melee only; scalable +1 Erő per 5 Mp, capped at Erő 23, not modeled) to every successful hit
/// for the duration; also lets the bare hand disarm like basic Fegyvertörés outside combat use.
/// </summary>
public sealed class BearClawMark : ISpell
{
    public string Name => "Bear claw mark";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 130;

    public int DurationInRounds => 3;

    public int GetDamage() => 2;
}
