using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Tornádó (Boszorkánymester — Természeti Mágia, Első Törvénykönyv p.254-255). Whips up a
/// deadly tornado that flings light objects and creatures into the air. Book models this as
/// flung objects/creatures taking fall damage (roughly 5D6-ish) when the tornado subsides;
/// simplified here to a flat 5D6 roll rather than a full toss-and-fall sequence.
/// </summary>
public sealed class Tornado : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Tornado";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 65;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 100;

    public int DurationInRounds => 270;

    [DiceThrow(ThrowType._5D6)]
    public int GetDamage() => diceThrow._5D6();
}
