using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Démoni birtok (Boszorkánymester — Necromancia, Első Törvénykönyv p.251). Curses an area so
/// that Life becomes unwelcome there; demonic energies drain the life force of anyone present or
/// entering. Book duration is "maradandó" (permanent) over a radius scaling with caster level;
/// approximated as a long but finite DurationInRounds, and the area effect is represented only
/// as a single target's per-round drain, not a true zone effect.
/// </summary>
public sealed class DemonicPossession : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Demonic possession";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 65;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 3600;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
