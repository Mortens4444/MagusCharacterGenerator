using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Kígyóvarázs II. (Boszorkány — Anyagi Mágia, Első Törvénykönyv p.208). Turns a rope into a
/// venomous snake (KÉ 45, TÉ 65, VÉ 45) that obeys the witch. 3D10 represents the venom damage on
/// a failed poison resistance (1D10 on success), simplified to the worse case. Duration is
/// kör/szint; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class RopeToSnakeII : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Rope to snake II";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 6;

    public int DurationInRounds => 5;

    [DiceThrow(ThrowType._3D10)]
    public int GetDamage() => diceThrow._3D10();
}
