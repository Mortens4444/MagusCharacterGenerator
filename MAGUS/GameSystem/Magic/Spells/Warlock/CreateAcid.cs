using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Savteremtés (Boszorkánymester — Anyagmágia, Első Törvénykönyv p.244). Turns water, wine, or
/// other liquid into corrosive acid, a cupful per round. Duration is kör/szint in the book;
/// level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class CreateAcid : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Create acid";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 9;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
