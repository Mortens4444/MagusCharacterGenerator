using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Hangorkán (Bárd — Hangmágia, Első Törvénykönyv p.138). A deafening blast audible for miles.
/// Book resolves this as 2D6 damage and permanent deafness on a failed Akaraterő-próba
/// (willpower save), or 1D6 and 1D10 minutes of temporary deafness on success; simplified here
/// to a flat 2D6 roll with no separate deafness mechanic, since Attacker has no such status.
/// </summary>
public sealed class SoundHurricane : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Sound hurricane";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => 4;

    public int ManaCost => 22;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._2D6)]
    public int GetDamage() => diceThrow._2D6();
}
