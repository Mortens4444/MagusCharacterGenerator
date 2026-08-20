using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Kígyóvarázs I. (Boszorkány — Misztikus képesség, Első Törvénykönyv p.204). Animates a rope
/// into an obedient constrictor snake that binds and squeezes a target for 1D6 Fp/round; the
/// accompanying combat-value penalties on the bound victim aren't separately modeled.
/// </summary>
public sealed class RopeToSnakeI : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Rope to snake I";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 10;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
