using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Égetés (Sámán — Zotgejt/Vérszimpatikus mágia, Második Törvénykönyv p.134). The shaman throws
/// the victim's Zotgejt puppet on a fire and dances around it; the real victim breaks out in
/// matching burns, taking 1D6 SP per round (once their FP is exhausted, ÉP instead) for up to
/// 4 rounds per shaman level.
/// </summary>
public sealed class PuppetBurning : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Puppet burning";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 37;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 4;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
